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
    public AudioSource audioCrowd;
    public AudioSource audioApplaudeCrowd;
    public AudioSource audioBooingCrowd;
    public int MonologResultWinValue = 4;
    public int levelphase = 0;
    private bool MonologActivated = false;
    private bool MonologEnded = false;
    private bool ifLoseTipsdisplayed = false;
    private bool ifWinDisplayed = false;
    private int tapCount = 0;
    public float fadeDuration = 2f;
    public List<string> Tips;
    public List<string> WinTips;
    public List<string> LoseTips;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("BoastPreviewIsDisplayed", 0) == 1)
        {
            LevelPreview.SetActive(false);
        }

        StartCoroutine(ShowTip(Tips));
    }
   
    // Update is called once per frame
    void Update()
    {
        if (levelphase == 1)
        {
            Mononlog.SetActive(true);
            MonologActivated = true;
            levelphase++;
        }
    }

    public void EndMonolog()
    {
        Mononlog.SetActive(false);
        
        if (Mononlog.GetComponent<Monologue>().MonologResult >= MonologResultWinValue)
        {
            StartCoroutine(ShowTip(WinTips));
            ifWinDisplayed=true;
        }
        else
        {
            StartCoroutine(ShowTip(LoseTips));
            ifLoseTipsdisplayed=true;
        }
        //TapToScreenToContinue.SetActive(false);
        
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
       
       
    }

    IEnumerator ShowTip(List<string> tips)
    {

        BoastTip.SetActive(true);
        TapToScreenToContinue.SetActive(false);

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
        BoastTip.SetActive(false);
        if (ifLoseTipsdisplayed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("BoastPreviewIsDisplayed", 1);
        }
            
        if (ifWinDisplayed)
        {
            SceneLoadManager.GetComponent<SceneChangeScript>().ChangeScene(2);
            PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted", 0) + 1);
        }
            
        ifLoseTipsdisplayed = false;
        ifWinDisplayed = false;
        levelphase++;
        StartCoroutine(FadeOutAudio());
    }

    IEnumerator FadeOutAudio()
    {
        if (audioCrowd == null) yield break;

        float startVolume = audioCrowd.volume;

        while (audioCrowd.volume > 0)
        {
            audioCrowd.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioCrowd.Stop();
        audioCrowd.volume = startVolume;
    }
}