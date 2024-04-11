using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingVolume : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        musicSlider.onValueChanged.AddListener(ChangeMusic);
        sfxSlider.onValueChanged.AddListener(ChangeSfx);

        ChangeMusic(musicSlider.value);
        ChangeSfx(sfxSlider.value);
    }

    public void ChangeMusic(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void ChangeSfx(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    //private void Start()
    //{
    //    if (PlayerPrefs.HasKey("MusicVolume"))
    //    {
    //        LoadVolume();
    //    }
    //    else
    //    {
    //        ChangeMusicAndSFX();
    //    }
    //}

    //public void ChangeMusicAndSFX()
    //{
    //    float volume1 = musicSlider.value;
    //    musicSource.volume = volume1;
    //    PlayerPrefs.SetFloat("MusicVolume", volume1);

    //    float volume2 = sfxSlider.value;
    //    sfxSource.volume = volume2;
    //    PlayerPrefs.SetFloat("SFXVolume", volume2);
    //}


    //public void LoadVolume()
    //{
    //    musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    //    sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    //    ChangeMusicAndSFX();


    //}
}
