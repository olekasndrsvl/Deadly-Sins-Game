using System;
using UnityEngine;

public class VolumeControllerOnScene : MonoBehaviour
{

    public AudioSource BackGroundAudio;

    void Start()
    {
        if (PlayerPrefs.HasKey("VolumeLevel"))
        {
            float savedVolume = PlayerPrefs.GetFloat("VolumeLevel");
            BackGroundAudio.volume = savedVolume;
        }
        else
        {
            BackGroundAudio.volume = 1.0f;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        SettingsController.onVolumeChanged += UpdateVolume;
    }

    private void OnDisable()
    {
        SettingsController.onVolumeChanged -= UpdateVolume;
    }

    void UpdateVolume()
    {
        float savedVolume = PlayerPrefs.GetFloat("VolumeLevel");
        BackGroundAudio.volume = savedVolume;
    }
}
