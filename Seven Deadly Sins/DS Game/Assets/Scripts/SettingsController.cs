using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class SettingsController : MonoBehaviour
{
    public GameObject LoadingScreen;
    public bool IsGodModeEnabled = false;
    public Text buttonText;

    public Slider volumeSlider;
    public AudioSource BackGroundAudio;
    public AudioSource OtherAudio;

    public static event System.Action onVolumeChanged;

    void Start()
    {
      
        IsGodModeEnabled = PlayerPrefs.GetInt("IsGodModeEnabled",0) == 1;
        float savedVolume = PlayerPrefs.GetFloat("VolumeLevel",1);
        volumeSlider.value = savedVolume;
        BackGroundAudio.volume = savedVolume;
        UpdateButtonText();
    }



    private void UpdateButtonText()
    {
        buttonText.text = IsGodModeEnabled ? "Вкл" : "Выкл";
    }



    public void OnGodButtonClick()
    {
        IsGodModeEnabled = !IsGodModeEnabled;
        UpdateButtonText();
    }
 
    public void ChangeVolume()
    {
        BackGroundAudio.volume = volumeSlider.value;
    }
   
    public void OnResetButtonClicked()
    {
        PlayerPrefs.DeleteAll();
    }

    public void OnBackButtonClicked()
    {
        gameObject.SetActive(false);
    }

    public void OnSaveButtonClicked()
    {
        PlayerPrefs.SetInt("IsGodModeEnabled",  IsGodModeEnabled ? 1 : 0);
        
        PlayerPrefs.SetFloat("VolumeLevel", BackGroundAudio.volume);
        onVolumeChanged.Invoke();
        PlayerPrefs.Save();
        gameObject.SetActive(false);

    }
    public void ChangeSceneWithDelay(int sceneNumber)
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(ChangeSceneCoroutine(sceneNumber, 1.5f));
    }

    private IEnumerator ChangeSceneCoroutine(int sceneNumber, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
    }

    private void OnDisable()
    {
        BackGroundAudio.Pause();
        OtherAudio.Play();
    }
    private void OnEnable()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeLevel");
        BackGroundAudio.Play();
        OtherAudio.Pause();
    }
}
