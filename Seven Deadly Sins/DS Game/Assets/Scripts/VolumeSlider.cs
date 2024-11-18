using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider; 
    public AudioSource Audio; 

    void Start()
    {
        if (PlayerPrefs.HasKey("VolumeLevel"))
        {
            float savedVolume = PlayerPrefs.GetFloat("VolumeLevel");
            volumeSlider.value = savedVolume; 
            Audio.volume = savedVolume; 
        }
        else
        {

            volumeSlider.value = 1.0f; 
            Audio.volume = 1.0f; 
        }
    }

    public void ChangeVolume()
    {
        Audio.volume = volumeSlider.value; 
        PlayerPrefs.SetFloat("VolumeLevel", Audio.volume); 
        PlayerPrefs.Save(); 
    }
}