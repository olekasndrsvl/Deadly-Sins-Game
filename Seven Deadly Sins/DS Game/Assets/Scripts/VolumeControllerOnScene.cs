using UnityEngine;

public class VolumeControllerOnScene : MonoBehaviour
{

    public AudioSource BackGroundAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
}
