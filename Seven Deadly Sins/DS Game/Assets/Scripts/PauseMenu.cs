using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject preview;
    private void Start()
    {
        if (PlayerPrefs.GetInt("LastScene") == SceneManager.GetActiveScene().buildIndex && PlayerPrefs.GetInt("IsItRespawn",0)==0)
        {
            if (preview!=null)
            preview.SetActive(false);
            
            Pause();
            menu.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("IsItRespawn", 0);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }
}
