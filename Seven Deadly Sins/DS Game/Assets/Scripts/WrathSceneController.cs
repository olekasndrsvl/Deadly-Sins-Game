using System;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;
using TMPro;

public class WrathSceneController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject wrathIcon;
    public GameObject tipsPanel;
    public List<GameObject> npcList;
    public List<GameObject> phrasesList;
    public List<Transform> positionsList;
    public List<string> tipsList;
    public List<string> WinTipsList;
    public float waitTime;
    public GameObject currentEnemy;
    public TMP_Text tipText;
    public GameObject LevelPreview;
    bool isStartedTipsShown = false;
    bool IsWinner = false;
    private int npcCounter;
    private int tipsCounter;
    private bool isTyping;
    public GameObject SceneChanger;
    public GameObject button;

    public void NextTip()
    {
        if (!isTyping&&tipsCounter<tipsList.Count)
        {
            StartCoroutine(TypeTip());
        }

        if (tipsCounter>=tipsList.Count)
        {
            tipsPanel.SetActive(false);
            if (!IsWinner)
            {
                SpawnNPC();
            }
            else
            {
                PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) + 1);
                SceneChanger.GetComponent<SceneChangeScript>().ChangeSceneWithDelay(2);
            }
        }
    }

    IEnumerator TypeTip()
    {
        isTyping = true;
        var sb = new StringBuilder();
        var tip = tipsList[tipsCounter];
        for (int i = 0; i < tip.Length; i++)
        {
            sb.Append(tip[i]);
            tipText.GetComponent<TMP_Text>().text = sb.ToString();
            yield return new WaitForSeconds(.05f);
        }
        
        isTyping = false;
        tipsCounter++;
    }
    private void Start()
    {
        TipConrtrollerScript.TipsTextMessage = "������ �� ����� ������, �� ��� ��� ����� ��� ����� ����!";
        TipConrtrollerScript.IsNewTextAdded = true;
        NextTip();
        if (PlayerPrefs.GetInt("WrathPreviewDisplayed", 0) == 1)
        {
            LevelPreview.SetActive(false);
        }
        PlayerPrefs.SetInt("WrathPreviewDisplayed",0);
        
        
    }

    public void Lose()
    {
        gameOverPanel.SetActive(true);
    }
    public void Replay()
    {
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("WrathPreviewDisplayed",1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void CLoseDialog()
    {
        StartCoroutine(WaitHit());
    }

    IEnumerator WaitHit()
    {
        wrathIcon.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        Destroy(currentEnemy);
        npcCounter++;
        wrathIcon.SetActive(false);
        if (npcCounter < 4) 
            SpawnNPC();
        else
        {
            tipsList = WinTipsList;
            tipsCounter = 0;
            NextTip();
        }
    }

    private void SpawnNPC()
    {
        var npc = Instantiate(npcList[npcCounter]);
        currentEnemy = npc;
        currentEnemy.transform.position = positionsList[npcCounter].position;
        currentEnemy.transform.localScale = positionsList[npcCounter].localScale;
        currentEnemy.GetComponent<WrathNPCLogic>().interactButton = button;
        currentEnemy.GetComponent<WrathNPCLogic>().controller = this;
        isStartedTipsShown=true;
        
    }
    public void TapButton()
    {
        phrasesList[npcCounter].SetActive(true);
        currentEnemy.GetComponent<WrathNPCLogic>().CloseButton();
    }

    private void Update()
    {
        if (isStartedTipsShown)
        {
            tipsCounter = 0;
            isStartedTipsShown = false;
        }
        
        if (npcCounter == 4 && !IsWinner)
        {
            tipsPanel.SetActive(true);
            IsWinner = true;
        }


    }
}
