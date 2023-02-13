using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSourceM;
    public float volumeMusic;
    public AudioSource audioSourceSFX;
    public float volumeSFX;

    [SerializeField] Slider volumeMSlider;
    [SerializeField] Slider volumeSFXSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.4f);
            Load();
        }
        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 0.4f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void Clic()
    {
        audioSourceSFX.Play();
    }

    public void ChangeMusicVolume()
    {
        audioSourceM.volume = volumeMSlider.value;
        Save();
    }

    public void ChangeSFXVolume()
    {
        audioSourceSFX.volume = volumeSFXSlider.value;
        Save();
    }

    private void Load ()
    {
        volumeMSlider.value = PlayerPrefs.GetFloat("musicVolume");
        volumeSFXSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void Save ()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeMSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", volumeSFXSlider.value);
    }

}
