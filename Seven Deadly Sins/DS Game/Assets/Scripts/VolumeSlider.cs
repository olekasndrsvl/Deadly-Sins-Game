using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource Audio; 
    public void ChangeVolume()
    {
        Audio.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeLevel",AudioListener.volume);
    }
    
}
