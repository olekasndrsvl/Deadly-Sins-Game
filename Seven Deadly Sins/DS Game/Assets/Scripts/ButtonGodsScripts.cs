using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGodScripts : MonoBehaviour
{
    public bool toggleValue;
    public Text buttonText; 

    void Start()
    {
        if (PlayerPrefs.HasKey("ToggleValue"))
        {
            toggleValue = PlayerPrefs.GetInt("ToggleValue") == 1;
        }
        else
        {
            toggleValue = true;
        }
        UpdateButtonText();
    }

    public void OnButtonClick()
    {
        toggleValue = !toggleValue;
        PlayerPrefs.SetInt("ToggleValue", toggleValue ? 1 : 0);
        PlayerPrefs.Save();
        UpdateButtonText(); 
    }

    private void UpdateButtonText()
    {
        buttonText.text = toggleValue ? "Вкл" : "Выкл"; 
    }
}