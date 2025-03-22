using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateGodTips : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
            if (PlayerPrefs.GetInt("IsPrideSceneTipDisplayed",0) == 1 && SceneManager.GetActiveScene().name == "PrideScene")
            {
                gameObject.SetActive(false);
            }
            if (PlayerPrefs.GetInt("IsEnvySceneTipDisplayed",0) == 1 && SceneManager.GetActiveScene().name == "EnvyScene")
            {
                gameObject.SetActive(false);
            }
            if (PlayerPrefs.GetInt("IsBoastSceneTipDisplayed",0) == 1 && SceneManager.GetActiveScene().name == "BoastScene")
            {
                gameObject.SetActive(false);
            }
            Debug.Log(PlayerPrefs.GetInt("IsGodModeEnabled", 0));

            if (PlayerPrefs.GetInt("IsGodModeEnabled",0) == 0)
            {
                gameObject.SetActive(false);          
            }
        

            if(SceneManager.GetActiveScene().name == "PrideScene") 
            { 
                PlayerPrefs.SetInt("IsPrideSceneTipDisplayed", 1); 
            }
            if(SceneManager.GetActiveScene().name == "EnvyScene") 
            { 
                PlayerPrefs.SetInt("IsEnvySceneTipDisplayed", 1); 
            }
            if(SceneManager.GetActiveScene().name == "BoastScene") 
            { 
                PlayerPrefs.SetInt("IsBoastSceneTipDisplayed", 1); 
            }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
