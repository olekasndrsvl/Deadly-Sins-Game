using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoastSceneController : MonoBehaviour
{
    public GameObject SceneLoadManager;
    public GameObject LevelPreview;
    public GameObject Mononlog;
    public GameObject BoastTip;
    public GameObject BoastTipText;
    public GameObject TapToScreenToContinue;
    public int MonologResultWinValue = 4;
    public int i = 0;
    private bool MonologActivated = false;
    private bool MonologEnded = false;
    public List<string> Tips;
    public List<string> WinTips;
    public List<string> LoseTips;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.GetInt("BoastPreviewIsDisplayed", 0) == 1)
        {
            LevelPreview.SetActive(false);
            i= Tips.Count;
        }
        TapToScreenToContinue.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       if(!MonologActivated)
       {
           if (Input.touchCount > 0)
           {
               TapToScreenToContinue.SetActive(false);
             
               if (Input.GetTouch(0).phase != TouchPhase.Ended) return;
               if (i < Tips.Count)
               {
                   BoastTip.SetActive(true);
                   StartCoroutine(SpellTip(Tips[i]));
               }
               else
               {
                   Mononlog.SetActive(true);
                   BoastTip.SetActive(false);
                   MonologActivated = true;
                   TapToScreenToContinue.SetActive(false);
               }


           }
       }
       else
       {
           if (MonologEnded)
           {
               BoastTip.SetActive(true);
               if (Mononlog.GetComponent<Monologue>().MonologResult >= MonologResultWinValue)
               {
                   if (Input.touchCount > 0)
                   {
                       TapToScreenToContinue.SetActive(false);
                       if (Input.GetTouch(0).phase != TouchPhase.Ended) return;
                       if (i < WinTips.Count)
                       {
                           StartCoroutine(SpellTip(WinTips[i]));
                       }
                       else
                       {
                          SceneLoadManager.GetComponent<SceneChangeScript>().ChangeScene(2);
                       }


                   }
               }
               else
               {
                   if (Input.touchCount > 0)
                   {  
                       TapToScreenToContinue.SetActive(false);
                       if (Input.GetTouch(0).phase != TouchPhase.Ended) return;
                       if (i < LoseTips.Count)
                       {
                           StartCoroutine(SpellTip(LoseTips[i]));
                       }
                       else
                       {
                           //Перезагрузка уровня
                           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                           PlayerPrefs.SetInt("BoastPreviewIsDisplayed",1);
                       }
                   }
               }
               
               
           }
       }
    }

    public void EndMonolog()
    {
        i = 0;
        TapToScreenToContinue.SetActive(false);
        MonologEnded = true;
    }
    IEnumerator SpellTip(string s)
    {
        BoastTipText.GetComponent<TMP_Text>().text = "";
        var sb = new StringBuilder();
        foreach (var x in s + '\n')
        {
            sb.Append(x);
            BoastTipText.GetComponent<TMP_Text>().text = sb.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        TapToScreenToContinue.SetActive(true);
        i++;
    }
}
