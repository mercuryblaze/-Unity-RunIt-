using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource MenuMusic;
    public AudioSource GameMusic;
    public AudioSource GameOverMusic;

    public AudioSource SFXCoin;
    public AudioSource SFXJump;
    public AudioSource SFXHit;

    public bool SoundMuted;
    public GameObject MutedImage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SoundOnOff()
    {
        if (SoundMuted)
        {
            MutedImage.SetActive(false);
            SoundMuted = false;
            UnmuteAll();
        }
        else
        {
            MutedImage.SetActive(true);
            SoundMuted = true;
            MuteAll();
        }
    }

    public void MuteAll()
    {
        MenuMusic.gameObject.SetActive(false);
        GameMusic.gameObject.SetActive(false);
        GameOverMusic.gameObject.SetActive(false);
        SFXCoin.gameObject.SetActive(false);
        SFXHit.gameObject.SetActive(false);
        SFXJump.gameObject.SetActive(false);
    }

    public void UnmuteAll()
    {
        MenuMusic.gameObject.SetActive(true);
        GameMusic.gameObject.SetActive(true);
        GameOverMusic.gameObject.SetActive(true);
        SFXCoin.gameObject.SetActive(true);
        SFXHit.gameObject.SetActive(true);
        SFXJump.gameObject.SetActive(true);
    }
}
