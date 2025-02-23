using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public class Monologue : MonoBehaviour
{
    private bool IsPrintingPhrase = false;
    public int MonologueResult;

    public GameObject MonologueWindow;
    public GameObject MonologueOptionButton1;
    public GameObject MonologueOptionButton2;
    public GameObject CloseButton;

    private TMP_Text MonologueText;
    private TMP_Text MonologueOption1;
    private TMP_Text MonologueOption2;

    public TypeDialogData CurrentMonologue;
    public AudioSource clickAudio;

    IEnumerator RunningCoroutine;

    void Start()
    {
        MonologueText = MonologueWindow.GetComponent<TMP_Text>();
        MonologueOption1 = MonologueOptionButton1.transform.GetChild(0).GetComponent<TMP_Text>();
        MonologueOption2 = MonologueOptionButton2.transform.GetChild(0).GetComponent<TMP_Text>();

        StartMonologue();
    }

    void StartMonologue()
    {
        MonologueText.text = "";
        RunningCoroutine = SpellPhrase(CurrentMonologue.Question);
        StartCoroutine(RunningCoroutine);

        MonologueOption1.text = CurrentMonologue.Answer1;
        MonologueOption2.text = CurrentMonologue.Answer2;
    }

    IEnumerator SpellPhrase(string s)
    {
        IsPrintingPhrase = true;
        MonologueOptionButton1.SetActive(false);
        MonologueOptionButton2.SetActive(false);

        StringBuilder sb = new StringBuilder();
        foreach (char x in s + '\n')
        {
            sb.Append(x);
            MonologueText.text = sb.ToString();
            yield return new WaitForSeconds(0.01f);
        }

        IsPrintingPhrase = false;
        if (!CloseButton.activeSelf)
        {
            MonologueOptionButton1.SetActive(true);
            MonologueOptionButton2.SetActive(true);
        }
    }

    private void PlayButtonClickSound()
    {
        clickAudio?.Play();
    }

    public void OnFirstOptionClicked()
    {
        PlayButtonClickSound();
        if (IsPrintingPhrase) return;

        MonologueResult++;
        ProcessNextMonologue(CurrentMonologue.ReactToAnswer1, CurrentMonologue.Answer1);
    }

    public void OnSecondOptionClicked()
    {
        PlayButtonClickSound();
        if (IsPrintingPhrase) return;

        MonologueResult--;
        ProcessNextMonologue(CurrentMonologue.ReactToAnswer2, CurrentMonologue.Answer2);
    }

    void ProcessNextMonologue(TypeDialogData nextMonologue, string answerText)
    {
        if (nextMonologue != null)
        {
            CurrentMonologue = nextMonologue;
            StartCoroutine(SpellPhrase(answerText + '\n' + CurrentMonologue.Question));
        }
        else
        {
            StartCoroutine(SpellPhrase(answerText));
            EndMonologue();
        }

        if (!string.IsNullOrEmpty(CurrentMonologue.Answer1) && !string.IsNullOrEmpty(CurrentMonologue.Answer2))
        {
            MonologueOption1.text = CurrentMonologue.Answer1;
            MonologueOption2.text = CurrentMonologue.Answer2;
        }
        else
        {
            EndMonologue();
        }
    }

    void EndMonologue()
    {
        MonologueOptionButton1.SetActive(false);
        MonologueOptionButton2.SetActive(false);
        SaveKarma();
        CloseButton.SetActive(true);
    }

    void SaveKarma()
    {
        int karma = PlayerPrefs.GetInt("KarmaState", 50);
        PlayerPrefs.SetInt("KarmaState", karma + MonologueResult);
    }

    public void CloseMonologueWindow()
    {
        PlayButtonClickSound();
        MonologueWindow.SetActive(false);
    }
}
