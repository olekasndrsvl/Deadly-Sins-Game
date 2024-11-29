using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateGodTips : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
            if (PlayerPrefs.GetInt("IsPrideSceneTipDisplayed",0) == 1)
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
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
