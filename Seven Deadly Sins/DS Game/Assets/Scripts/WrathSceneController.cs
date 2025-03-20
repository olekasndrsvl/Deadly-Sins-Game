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
    public float waitTime;
    public GameObject currentEnemy;
    public TMP_Text tipText;
    
    private int npcCounter;
    private int tipsCounter;
    private bool isTyping;

    public GameObject button;

    public void NextTip()
    {
        if (!isTyping&&tipsCounter<3)
        {
            StartCoroutine(TypeTip());
        }

        if (tipsCounter>=3)
        {
            tipsPanel.SetActive(false);
            SpawnNPC();
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
        NextTip();
    }

    public void Lose()
    {
        gameOverPanel.SetActive(true);
    }
    public void Replay()
    {
        PlayerPrefs.Save();
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
        if (npcCounter < 4) SpawnNPC();
    }

    private void SpawnNPC()
    {
        var npc = Instantiate(npcList[npcCounter]);
        currentEnemy = npc;
        currentEnemy.transform.position = positionsList[npcCounter].position;
        currentEnemy.transform.localScale = positionsList[npcCounter].localScale;
        currentEnemy.GetComponent<WrathNPCLogic>().interactButton = button;
        currentEnemy.GetComponent<WrathNPCLogic>().controller = this;
        
    }
    public void TapButton()
    {
        phrasesList[npcCounter].SetActive(true);
        currentEnemy.GetComponent<WrathNPCLogic>().CloseButton();
    }
    
}
