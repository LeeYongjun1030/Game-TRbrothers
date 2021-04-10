using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    
    public string chosenCharacter;
    public GameObject choiceArrow;
    public Animator anim;
    public Button lArrowBtn;
    public Button rArrowBtn;
    public float maxSpeed;
    public bool onFloor;
    public ParticleSystem shotParticle;
    LArrowPressed lp;
    RArrowPressed rp;
    Rigidbody2D rb;
    Transform tr;
    public Vector2 collisionNormal;


    [Header("Raycast")]
    Vector2 frontRayPos;
    Vector2 backRayPos;
    RaycastHit2D frontRayHit;
    RaycastHit2D backRayHit;
    float frontLegPos;
    float legWidth;
    float legDir;
    float distance;
    int layerMask;

    [Header("Skill")]
    public float bulletFlyTime;
    public GameObject magazine; // magazine은 탄알집이라는 뜻.
    GameObject bulletPos;
    Transform bulletPosTr;
    GameObject[] bullet;
    int bulletNum;
    int bulletIndex;
    int bulletTempIndex;

    // Start is called before the first frame update
    void Awake()
    {
       bulletPos = gameObject.transform.GetChild(1).gameObject;
       bulletNum = magazine.gameObject.transform.childCount;
       bullet = new GameObject[bulletNum];
       for (int i = 0; i < bulletNum; i++)
       {
            bullet[i] = magazine.gameObject.transform.GetChild(i).gameObject;
        }
        bulletIndex = 0;
        bulletTempIndex = 0;
        bulletPosTr = bulletPos.GetComponent<Transform>();

        chosenCharacter = "Rabbit";

        rb = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();
        lp = lArrowBtn.GetComponent<LArrowPressed>();
        rp = rArrowBtn.GetComponent<RArrowPressed>();

        InitRayCast();
    }
    private void Start()
    {
        StartCoroutine("OnFloorCheck");
        StartCoroutine("AnimWalk");
        StartCoroutine("AnimJump");
        StartCoroutine("MoveManaging");
    }

    void InitRayCast()
    {
     
    layerMask = 
    ((1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("Coin")) | (1 << LayerMask.NameToLayer("Flag")));  
            
      
        legWidth = gameObject.tag == "Rabbit" ? 0.4f : 0.7f;
        distance = gameObject.tag == "Rabbit" ? 1.4f : 0.8f;
        frontLegPos = gameObject.tag == "Rabbit" ? 0.2f : 0.2f;
    }
    IEnumerator OnFloorCheck()
    {
        while (true)
        {
            legDir = -tr.localScale.x;

            frontRayPos = new Vector2(transform.position.x - legDir*frontLegPos, transform.position.y);
            //front ray
            Debug.DrawRay(frontRayPos, Vector2.down * distance, new Color(0, 1, 0));
            frontRayHit = Physics2D.Raycast(frontRayPos, Vector2.down,distance,~layerMask);

            
            backRayPos = new Vector2(transform.position.x + legWidth * legDir, transform.position.y);
            //back ray
            Debug.DrawRay(backRayPos, Vector2.down * distance, new Color(1, 0, 0));
            backRayHit = Physics2D.Raycast(backRayPos, Vector2.down, distance, ~layerMask);

            if (frontRayHit.collider != null | backRayHit.collider != null)
            {
               
                 onFloor = true;
               
            }
            else
            {
                onFloor = false;
            }
            yield return null;
        }
    }
    public void Jump()
    {
        if (onFloor&& chosenCharacter == gameObject.tag)
        {
            EffectSoundManager.soundManager.JumpSound();
            rb.AddForce(Vector2.up*11, ForceMode2D.Impulse);
        }
        
    }
    IEnumerator AnimJump()
    {
        while (true)
        {
            if (rb.velocity.y<4)
            {
                anim.SetBool("Jump", false);
            }
            else
            {
                anim.SetBool("Jump", true);
            }
            yield return null;
        }
      
    }
    public void Skill()
    {
        if(chosenCharacter == gameObject.tag)
        {
            EffectSoundManager.soundManager.ShotSound();
            anim.SetTrigger("Skill");

            bullet[bulletIndex].SetActive(true);
            bullet[bulletIndex].transform.position = bulletPosTr.position;
            Invoke("OffBullet", bulletFlyTime);

            //loof
            bulletIndex += 1;
            if (bulletIndex.Equals(bulletNum))
            {
                bulletIndex = 0;
            }
        }
        
    }
    public void OffBullet()
    {
        bullet[bulletTempIndex].SetActive(false);

        //loof
        bulletTempIndex += 1;
        if (bulletTempIndex.Equals(bulletNum))
        {
            bulletTempIndex = 0;
        }
    }
   

        IEnumerator AnimWalk()
    {
        while (true)
        {
            //Animation-walk
            if (Mathf.Abs(rb.velocity.x) < 1.5f)
                anim.SetBool("Walk", false);
            else
                anim.SetBool("Walk", true);

            yield return null;
        }

    }

    IEnumerator MoveManaging()
    {
        while (true)
        {
            if (chosenCharacter == gameObject.tag)
            {
                float h = 0;
                if (lp.pressed)
                {
                    h = -1;

                    tr.localScale = new Vector3(-1, 1, 1);


                }
                else if (rp.pressed)
                {
                    h = 1;

                    tr.localScale = new Vector3(1, 1, 1);

                }

                rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);

                if (rb.velocity.x > maxSpeed)
                    rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
                else if (rb.velocity.x < -maxSpeed)
                    rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);

                if (rb.velocity.y > maxSpeed * 10)
                    rb.velocity = new Vector2(rb.velocity.x, maxSpeed * 10);

            }

            yield return null;
        }

    }

    public void ChangeCharacter()
    {
        if (chosenCharacter == "Rabbit")
        {
            chosenCharacter = "Turtle";
        }
        else if (chosenCharacter == "Turtle")
        {
            chosenCharacter = "Rabbit";
        }

        if (chosenCharacter == gameObject.tag)
        {
            choiceArrow.SetActive(true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Box")
        {
            collisionNormal = collision.contacts[0].normal;
            if (collisionNormal.y > 0.7)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Box":
            collisionNormal = collision.contacts[0].normal;
            if (collisionNormal.y > 0.7)
            {
                 //측면에서 밀었을때만 상자가 움직일 수 있도록 한다.
                 Rigidbody2D otherRb = collision.rigidbody;
                otherRb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
             }
              break;

        }
      
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Box")
        {   
            Rigidbody2D otherRb = collision.rigidbody;
            otherRb.constraints = RigidbodyConstraints2D.FreezeRotation;  
        }
    }
}
