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
                    LevelDesciption.text = "�� ������ ������� �� ������� \"����\"?";
                  
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "���� ��� ���� � ���� �����! �������� � ����� �������� �������!";
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
                    LevelDesciption.text = "�� ������ ������� �� ������� \"����\"?";
                  
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "���� ��� ���� � ���� �����! �������� � ����� �������� �������!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
              
                break;
            case 6:
                if (PlayerPrefs.GetInt("KarmaState", 0) > 110)
                { 
                    LevelChoice.SetActive(true);
                    CurrentSceneToLoad = "VanityScene";
                    LevelDesciption.text = "�� ������ ������� �� ������� \"���������\"?";
                    
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "���� ��� ���� � ���� �����! �������� � ����� �������� �������!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
               
                break;
            case 7:
                if (PlayerPrefs.GetInt("KarmaState", 0) > 60)
                {
                    LevelChoice.SetActive(true);
                    CurrentSceneToLoad = "PrideScene";
                    LevelDesciption.text = "�� ������ ������� �� ������� \"�������\"?";
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "���� ��� ���� � ���� �����! �������� � ����� �������� �������!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                
                break;
            case 8:
                if (PlayerPrefs.GetInt("KarmaState", 0) > 100)
                { 
                    LevelChoice.SetActive(true);
                    CurrentSceneToLoad = "BoastScene";
                    LevelDesciption.text = "�� ������ ������� �� ������� \"�����������\"?";
                    
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "���� ��� ���� � ���� �����! �������� � ����� �������� �������!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
               
                break;
            case 9:
               
                if (PlayerPrefs.GetInt("KarmaState", 0) > 80)
                { 
                    LevelChoice.SetActive(true);
                    CurrentSceneToLoad = "EnvyScene";
                    LevelDesciption.text = "�� ������ ������� �� ������� \"�������\"?";
                   
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "���� ��� ���� � ���� �����! �������� � ����� �������� �������!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                break;
            case 10:
               
                if (PlayerPrefs.GetInt("KarmaState", 0) > 70)
                {
                    LevelChoice.SetActive(true);
                    CurrentSceneToLoad = "GreedScene";
                    LevelDesciption.text = "�� ������ ������� �� ������� \"��������\"?";
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage = "���� ��� ���� � ���� �����! �������� � ����� �������� �������!";
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
                    TipConrtrollerScript.TipsTextMessage = "�� ��� �� ������� ���� ��������, ��� ���!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                

              
                //LevelDesciption.text = "�� ������ ������� � ������ ����?";
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
