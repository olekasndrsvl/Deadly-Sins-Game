using UnityEngine;

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
        

        if(PlayerPrefs.HasKey("ToggleValue"))
        {
            if (PlayerPrefs.GetInt("ToggleValue") == 0)
            {
                gameObject.SetActive(false);          
            }
        }
        else
        {
            gameObject.SetActive(false);
        }


        PlayerPrefs.SetInt("IsPrideSceneTipDisplayed", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
