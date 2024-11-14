using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    public AudioClip clickSound;  

    private AudioSource audioSource;  

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        
        // Find all buttons that are children of this object
        Button[] buttons = GetComponentsInChildren<Button>();


        // Loop through each button and add a listener for the onClick event
        foreach (Button button in buttons)
        {
            // Add a listener to play the click sound when the button is clicked
            button.onClick.AddListener(PlayClickSound);
        }
    }

    private void PlayClickSound()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }
}