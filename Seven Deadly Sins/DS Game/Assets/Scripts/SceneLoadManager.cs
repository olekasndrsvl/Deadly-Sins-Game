using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using Unity.VisualScripting;

public class SceneLoadManager : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject Logo;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("IsFirstlyLoaded"))
        {
            director.Pause();
            Logo.SetActive(true);
            //SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
        }
        else
        {
            PlayerPrefs.SetInt("IsFirstlyLoaded", 0);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
