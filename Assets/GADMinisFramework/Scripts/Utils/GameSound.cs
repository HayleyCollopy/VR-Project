using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    public AudioClip bgm;
    public AudioClip gameWin;
    public AudioClip gameLose;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public void PlayMusic()
    {
        musicSource.clip = bgm;
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void PlayWin()
    {
        sfxSource.clip = gameWin;
        sfxSource.Play();
    }
    public void PlayLose()
    {
        sfxSource.clip = gameLose;
        sfxSource.Play();
    }
}
