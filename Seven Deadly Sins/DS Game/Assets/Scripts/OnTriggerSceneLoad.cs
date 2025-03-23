using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class OnTriggerSceneLoad : MonoBehaviour
{
    public GameObject SceneChanger;
    public GameObject LoadingScreen;
    public GameObject LevelChoice;
    public TextMeshProUGUI LevelDesciption;
    public int NumberOfLoadingScene;
    static string CurrentSceneToLoad;
    public void OnTriggerEnter2D(Collider2D other)
    {
      
        switch (NumberOfLoadingScene)
        {
            case 3:
                if (PlayerPrefs.GetInt("KarmaState", 0) > 190)
                {  
                    LevelChoice.SetActive(true);
                    CurrentSceneToLoad = "WrathScene";
                    LevelDesciption.text = "Вы хотите перейти на уровень \"Гнев\"?";
                  
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "Тебе еще рано в этот котел! Справься с более простыми грехами!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                break;
            case 4:

                break;
            case 5:
                if (PlayerPrefs.GetInt("KarmaState", 0) > 190)
                {  
                    LevelChoice.SetActive(true);
                    CurrentSceneToLoad = "WrathScene";
                    LevelDesciption.text = "Вы хотите перейти на уровень \"Гнев\"?";
                  
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "Тебе еще рано в этот котел! Справься с более простыми грехами!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
              
                break;
            case 6:
                if (PlayerPrefs.GetInt("KarmaState", 0) > 110)
                { 
                    LevelChoice.SetActive(true);
                    CurrentSceneToLoad = "VanityScene";
                    LevelDesciption.text = "Вы хотите перейти на уровень \"Тщеславие\"?";
                    
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "Тебе еще рано в этот котел! Справься с более простыми грехами!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
               
                break;
            case 7:
                if (PlayerPrefs.GetInt("KarmaState", 0) > 60)
                {
                    LevelChoice.SetActive(true);
                    CurrentSceneToLoad = "PrideScene";
                    LevelDesciption.text = "Вы хотите перейти на уровень \"Гордыня\"?";
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "Тебе еще рано в этот котел! Справься с более простыми грехами!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                
                break;
            case 8:
                if (PlayerPrefs.GetInt("KarmaState", 0) > 100)
                { 
                    LevelChoice.SetActive(true);
                    CurrentSceneToLoad = "BoastScene";
                    LevelDesciption.text = "Вы хотите перейти на уровень \"Хваставство\"?";
                    
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "Тебе еще рано в этот котел! Справься с более простыми грехами!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
               
                break;
            case 9:
               
                if (PlayerPrefs.GetInt("KarmaState", 0) > 80)
                { 
                    LevelChoice.SetActive(true);
                    CurrentSceneToLoad = "EnvyScene";
                    LevelDesciption.text = "Вы хотите перейти на уровень \"Зависть\"?";
                   
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "Тебе еще рано в этот котел! Справься с более простыми грехами!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                break;
            case 10:
               
                if (PlayerPrefs.GetInt("KarmaState", 0) > 70)
                {
                    LevelChoice.SetActive(true);
                    CurrentSceneToLoad = "GreedScene";
                    LevelDesciption.text = "Вы хотите перейти на уровень \"Жадность\"?";
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "Тебе еще рано в этот котел! Справься с более простыми грехами!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                
                break;
            default:
                LevelChoice.SetActive(false);
                if (PlayerPrefs.GetInt("KarmaState", 0) > 200)
                {
                    CurrentSceneToLoad = "OutroScene";
                    SceneChanger.GetComponent<SceneChangeScript>().ChangeSceneWithDelay(5);
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "Ты еще не окончил путь очищения, сын мой!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                

              
                //LevelDesciption.text = "Вы хотите перейти к финалу игры?";
                break;
        }

    }
    public void OnConfirmButtonClicked()
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene(CurrentSceneToLoad, LoadSceneMode.Single);
    }
    public void Disagreement()
    {
        LevelChoice.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
