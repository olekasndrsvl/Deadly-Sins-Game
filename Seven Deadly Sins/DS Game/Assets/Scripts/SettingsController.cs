using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsController : MonoBehaviour
{
    public GameObject LoadingScreen;
    public bool IsGodModeEnabled = false;
    public Text buttonText;

    public Slider volumeSlider;
    public AudioSource BackGroundAudio;

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
        ChangeSceneWithDelay(PlayerPrefs.GetInt("LastScene",1));
    }

    public void OnSaveButtonClicked()
    {
        PlayerPrefs.SetInt("IsGodModeEnabled",  IsGodModeEnabled ? 1 : 0);
      
        PlayerPrefs.SetFloat("VolumeLevel", BackGroundAudio.volume);
        PlayerPrefs.Save();
        ChangeSceneWithDelay(PlayerPrefs.GetInt("LastScene", 1));

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
}
