using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VanitySceneController : MonoBehaviour
{
    public static VanitySceneController instance;
    public GameObject TipPanel;
    public GameObject[] Holders;
    public GameObject SceneLoadManager;
    public GameObject LevelPreview;
    public Animator vanityanimator;
    public GameObject VanityTip;
    public GameObject VanityTipText;
    public GameObject TapToScreenToContinue;
    public List<string> Tips;
    public List<List<string>> WinTips;
    public List<List<string>> LoseTips;
    public static bool IsLoseTipsShown = false;
    public static bool IsWinTipsShown1 = false;
    public List<string> Wealthies1;
    public List<string> Wealthies2;
    public List<string> Wealthies3;
    static int levelphase = 0;

    private static int i = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        WinTips = new List<List<string>>()
        {
            new List<string>() { "1", "2,", "3" },
            new List<string>() { "4", "5,", "6" },
            new List<string>() { "7", "8,", "9" },
            new List<string>() { "F", "i,", "n" }
        };

        LoseTips = new List<List<string>>()
        {
            new List<string>() { "11", "21,", "31" },
            new List<string>() { "14", "15,", "16" },
            new List<string>() { "17", "18,", "19" }
        };

        StartCoroutine(ShowTip(Tips));
        for (int j = 0; j < 3; j++)
        {
            Holders[j].GetComponent<Text>().text = Wealthies1[j];

        }
      
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(levelphase);
    }



    

    public static void ShowLoseTip()
    {
        instance.StartCoroutine(instance.ShowTip(instance.LoseTips[levelphase]));
    }

    public static void IncLevelphase()
    {
        levelphase++;
        instance.StartCoroutine(instance.ShowTip(instance.WinTips[levelphase]));

        if (PlayerPrefs.HasKey("KarmaState"))
        {
            PlayerPrefs.SetInt("KarmaState", PlayerPrefs.GetInt("KarmaState") + 10);

        }
        else
        {
            PlayerPrefs.SetInt("KarmaState", 50);


        }

        switch (levelphase)
        {
            case 1:
                for (int j = 0; j < 3; j++)
                {
                    instance.Holders[j].GetComponent<Text>().text = instance.Wealthies2[j];

                }

                break;
            case 2:

                for (int j = 0; j < 3; j++)
                {
                    instance.Holders[j].GetComponent<Text>().text = instance.Wealthies3[j];

                }

                break;
            case 3:
                
                instance.StartCoroutine(instance.ShowTip(instance.WinTips[levelphase]));
              
                break;


        }

        if (levelphase < 3)
        {

            SlotCounter.Instance.Reset();
        }
    }

    IEnumerator ShowTip(List<string> tips)
        {
            TipPanel.SetActive(true);
            VanityTip.SetActive(true);
            TapToScreenToContinue.SetActive(false);
            vanityanimator.SetBool("IsAppeared", false);
            foreach (string tip in tips)
            {
                yield return StartCoroutine(SpellTip(tip));
            
                TapToScreenToContinue.SetActive(true);
            
                bool tapped = false;
            
                while (!tapped)
                {
                    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        tapped = true;
                    }

                    yield return null;
                }

                TapToScreenToContinue.SetActive(false);
            }

       
            vanityanimator.SetBool("IsAppeared", true);
            TipPanel.SetActive(false);
            if (levelphase == 3)
            {
                instance.SceneLoadManager.GetComponent<SceneChangeScript>().ChangeSceneWithDelay(2);
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
