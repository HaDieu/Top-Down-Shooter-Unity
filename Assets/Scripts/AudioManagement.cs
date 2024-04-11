using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioSource musicAudiosource;
    public AudioSource sfxAudioSource;

    public AudioClip musicClip;
    public AudioClip gunClip;
    public AudioClip gameOverClip;

    public void Start()
    {
        musicAudiosource.clip = musicClip;
        musicAudiosource.Play();
    }

    public void PlaySfx(AudioClip sfxClip)
    {
        sfxAudioSource.clip = sfxClip;
        sfxAudioSource.PlayOneShot(sfxClip);
    }

    public void StopMusic()
    {
        musicAudiosource.Stop();
    }
}
