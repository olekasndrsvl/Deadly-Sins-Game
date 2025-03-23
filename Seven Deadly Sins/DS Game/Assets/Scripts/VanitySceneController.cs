using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VanitySceneController : MonoBehaviour
{
    public GameObject TipPanel;
    public GameObject[] Holders;
    public GameObject SceneLoadManager;
    public GameObject LevelPreview;
    public Animator vanityanimator;
    public GameObject VanityTip;
    public GameObject VanityTipText;
    public GameObject TapToScreenToContinue;
    public List<string> Tips;
    public List<string> WinTips;
    public List<string> LoseTips;
    public static bool IsLoseTipsShown = false;
    public List<string> Wealthies1;
    public List<string> Wealthies2;
    public List<string> Wealthies3;
    static int levelphase = -1;
    private int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VanityTipText.GetComponent<TMP_Text>().text = Tips[i];
        i++;
    }

    // Update is called once per frame
    void Update()
    {
    //   Debug.Log(levelphase);
        if (IsLoseTipsShown)
        {
          
            
            Debug.Log(IsLoseTipsShown.ToString());
            //TapToScreenToContinue.SetActive(true);
            //VanityTip.SetActive(true);
            TipPanel.SetActive(true);
            ShowTip(LoseTips);
           // Debug.Log(LoseTips.Count);
        }
        else
        {
            switch (levelphase)
            {
                //Начальные подсказки показываем
                case -1:
                    TipPanel.SetActive(true);
                    ShowTip(Tips);
                    break;
                case 0:
                    TipPanel.SetActive(false);
                    for (int j = 0; j < 3; j++)
                    {
                        Holders[j].GetComponent<Text>().text = Wealthies1[j];
                       
                    }
                   
                    break;
                case 1:
                    TipPanel.SetActive(false);
                    for (int j = 0; j < 3; j++)
                    {
                        Holders[j].GetComponent<Text>().text = Wealthies2[j];
                        
                    }
                  
                    break;
                case 2:
                    TipPanel.SetActive(false);
                    for (int j = 0; j < 3; j++)
                    {
                        Holders[j].GetComponent<Text>().text = Wealthies3[j];
                       
                    } 
                 
                    break;
                case 3:
                    TipPanel.SetActive(true);
                    ShowTip(WinTips);
                    break;
            }
        }
        
        
        
    }

    public static void ShowLoseTip()
    {
        IsLoseTipsShown = true;
    }
    public static void IncLevelphase()
    {
        levelphase++;
        if (levelphase<3)
        {
          
            SlotCounter.Instance.Reset();
        }
      
    }
    void ShowTip(List<string> tips)
    {
        if (Input.touchCount > 0)
        {
            TapToScreenToContinue.SetActive(false);
             
            if (Input.GetTouch(0).phase != TouchPhase.Ended) 
                return;
            
            if (i < tips.Count)
            {
                vanityanimator.SetBool("IsAppeared",false);
                VanityTip.SetActive(true);
                StartCoroutine(SpellTip(tips[i]));
            }
            else
            {
                vanityanimator.SetBool("IsAppeared",true);
                TapToScreenToContinue.SetActive(false);
                
                if (levelphase == 3)
                {
                   SceneLoadManager.GetComponent<SceneChangeScript>().ChangeSceneWithDelay(2);
                }
                if (levelphase == -1)
                    levelphase++;
                i = 0;
                IsLoseTipsShown = false;
                

            }


        }
    }
    
    IEnumerator SpellTip(string s)
    {
        VanityTipText.GetComponent<TMP_Text>().text = "";
        var sb = new StringBuilder();
        foreach (var x in s + '\n')
        {
            sb.Append(x);
            VanityTipText.GetComponent<TMP_Text>().text = sb.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        TapToScreenToContinue.SetActive(true);
        i++;
    }
}
