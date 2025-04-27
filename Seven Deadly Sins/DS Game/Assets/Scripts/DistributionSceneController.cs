using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DistributionSceneController : MonoBehaviour
{
    public List<GameObject> boilers;
    public GameObject boilereffect;
    public RuntimeAnimatorController animator;
    public GameObject player;
    private Vector3 pos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (PlayerPrefs.GetInt("LevelsCompleted",0))
        {
            case 1:
                TipConrtrollerScript.TipsTextMessage =
                    "�� �������� � ���, ����, � ����� ������ �� �������, ������ ������ ��� �����!";
                TipConrtrollerScript.IsNewTextAdded = true;
                pos = new Vector3(boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.position.x, boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.position.y + 1, 0);
                Instantiate(boilereffect, pos, boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.rotation);
                break;
            case 2:
                if (PlayerPrefs.GetInt("KarmaState", 0) < 57)
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "�� ������� �� ������ ����!? ������ ���� �������� ����� ��������� � ���� �����!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                    PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) - 1);
                  
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "� ���� �� ������ �����, ��� �������,����!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                pos = new Vector3(boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.position.x, boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.position.y + 1, 0);
                Instantiate(boilereffect, pos, boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.rotation);
                break;
            case 3:
                if (PlayerPrefs.GetInt("KarmaState", 0) < 58)
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "�� ������� �� ������ ����!? ������ ���� �������� ����� ��������� � ���� �����!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                    PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) - 1);
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "�������� ������,����! �� ������� ��� ���� ������� ��������!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                pos = new Vector3(boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.position.x, boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.position.y + 1, 0);
                Instantiate(boilereffect, pos, boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.rotation);
                break;
            case 4:
                if (PlayerPrefs.GetInt("KarmaState", 0) < 60)
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "�� ������� �� ������ ����!? ������ ���� �������� ����� ��������� � ���� �����!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                    PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) - 1);
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "������ ���������� ������� � ����� �������, �� �� ���������. � ��� �� ���� ���� �� ����������, ����!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                pos = new Vector3(boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.position.x, boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.position.y + 1, 0);
                Instantiate(boilereffect, pos, boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.rotation);
                break;
            
            case 5:
                if (PlayerPrefs.GetInt("KarmaState", 0) < 90)
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "�� ������� �� ������ ����!? ������ ���� �������� ����� ��������� � ���� �����!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                    PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) - 1);
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "��� ���� ������ ���������� ����������, �� �� ���������!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                pos = new Vector3(boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.position.x, boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.position.y + 1, 0);
                Instantiate(boilereffect, pos, boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.rotation);
                break;
            case 6:
                if (PlayerPrefs.GetInt("KarmaState", 0) < 110)
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "�� ������� �� ������ ����!? ������ ���� �������� ����� ��������� � ���� �����!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                    PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) - 1);
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "������� �������,����! ���� �� � �������...";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                pos = new Vector3(boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.position.x, boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.position.y + 1, 0);
                Instantiate(boilereffect, pos, boilers[PlayerPrefs.GetInt("LevelsCompleted",0)-1].transform.rotation);
                break;
            case 7:
                TipConrtrollerScript.TipsTextMessage =
                    "�� ������ ���� ��������, ��� ���! ��������� � ������ �� ���, �� ����� �� �����!";
                TipConrtrollerScript.IsNewTextAdded = true;
                player.GetComponent<Animator>().runtimeAnimatorController = animator;
                break;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(PlayerPrefs.GetInt("KarmaState", 0));
        //Debug.Log(PlayerPrefs.GetInt("LevelsCompleted", 0) );
    }
}
