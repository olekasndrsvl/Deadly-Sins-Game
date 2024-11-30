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
        Debug.Log(PlayerPrefs.GetInt("IsFirstlyLoaded", 1));

        if (PlayerPrefs.GetInt("IsIntroFirstlyLoaded",1)==0)
        {
            director.Pause();
            Logo.SetActive(true);
        
        }
        PlayerPrefs.SetInt("IsIntroFirstlyLoaded", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
