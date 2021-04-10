using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundManager : MonoBehaviour
{
    public static EffectSoundManager soundManager;//전역변수를 위한 인스턴스 생성
    //clip info
    // 0jump // 1shot// 2coin // 3win //4lose //5Die //6error //7explosion
    public AudioClip[] audioClip;
    AudioSource audioSource;

    private void Awake()
    {
        soundManager = this;

        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void JumpSound()
    {
        audioSource.PlayOneShot(audioClip[0]);
    }
    public void ShotSound()
    {
        audioSource.PlayOneShot(audioClip[1]);
    }
    public void CoinSound()
    {
        audioSource.PlayOneShot(audioClip[2]);
    }
    public void WinSound()
    {
        audioSource.PlayOneShot(audioClip[3]);
    }
    public void LoseSound()
    {
        audioSource.PlayOneShot(audioClip[4]);
    }
    public void DieSound()
    {
        audioSource.PlayOneShot(audioClip[5]);
    }
    public void ErrorSound()
    {
        audioSource.PlayOneShot(audioClip[6]);
    }
    public void ExplosionSound()
    {
        audioSource.PlayOneShot(audioClip[7]);
    }
    public void BirdSound()
    {
        audioSource.PlayOneShot(audioClip[8]);
    }
    public void BridgeSound()
    {
        audioSource.PlayOneShot(audioClip[9]);
    }
    public void CloudSound()
    {
        audioSource.PlayOneShot(audioClip[10]);
    }

    public void RewardSound()
    {
        audioSource.PlayOneShot(audioClip[11]);
    }
}
