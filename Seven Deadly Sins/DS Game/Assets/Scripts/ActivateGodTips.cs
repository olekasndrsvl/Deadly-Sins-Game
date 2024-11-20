using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateGodTips : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("IsPrideSceneTipDisplayed"))
        {
            if (PlayerPrefs.GetInt("IsPrideSceneTipDisplayed") == 1)
            {
                gameObject.SetActive(false);
            }
        }
       
        if(PlayerPrefs.HasKey("IsGodModeEnabled"))
        {

            Debug.Log(PlayerPrefs.GetInt("IsGodModeEnabled"));
            if (PlayerPrefs.GetInt("IsGodModeEnabled") == 0)
            {
                gameObject.SetActive(false);          
            }
        }
        else
        {
            gameObject.SetActive(false);
        }

        if(SceneManager.GetActiveScene().name == "PrideScene") 
        { 
            PlayerPrefs.SetInt("IsPrideSceneTipDisplayed", 1); 
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
