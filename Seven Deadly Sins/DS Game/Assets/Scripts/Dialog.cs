using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TMPro;

using UnityEngine;

public class Dialog : MonoBehaviour
{
   
    public string NameNPC = "";
    private bool IsPrintingPhrase = false;
    public int DialogResult;
    // needs link to text gameobject
    public GameObject DialogQuestion;

    public GameObject DialogWindow;
    public GameObject DialogAnswerButton1;
    public GameObject DialogAnswerButton2;
    GameObject DialogAnswer1;
    GameObject DialogAnswer2;
    public GameObject CloseButton;
    //                                            
    public TypeDialogData CurrentDialog;

    public AudioSource clickAudio;
    public AudioClip[] speachSounds;
    public AudioSource speachAudio;

    IEnumerator RunningCoroutine;

    // Start is called before the first frame update
    void Start()
    {

        DialogAnswer1 = DialogAnswerButton1.transform.GetChild(0).gameObject;
        DialogAnswer2 = DialogAnswerButton2.transform.GetChild(0).gameObject;

        DialogQuestion.GetComponent<TMP_Text>().text = "";

        //                            
        //CurrentDialog = p1;
        RunningCoroutine = SpellPhrase(CurrentDialog.Question);
        StartCoroutine(RunningCoroutine);

        DialogAnswer1.GetComponent<TMP_Text>().text = CurrentDialog.Answer1;
        DialogAnswer2.GetComponent<TMP_Text>().text = CurrentDialog.Answer2;



    }

    void Cleaner()
    {
        var s = DialogQuestion.GetComponent<TMP_Text>().text;
        var a = s.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        if (a.Length > 4 || s.Length > 100)
        {
            DialogQuestion.GetComponent<TMP_Text>().text = a.Last() + '\n';
        }

    }

    //          -        
    IEnumerator SpellPhrase(string s)
    {
        Cleaner();
        IsPrintingPhrase = true;
        DialogAnswerButton1.SetActive((false));
        DialogAnswerButton2.SetActive((false));

        var sb = new StringBuilder(DialogQuestion.GetComponent<TMP_Text>().text);

        Queue<char> speakerBuffer = new Queue<char>();
        int lastSpeaker = 0;

        foreach (var x in s + '\n')
        {

            sb.Append(x);
            DialogQuestion.GetComponent<TMP_Text>().text = sb.ToString();

            Debug.Log(speachSounds);

            if (speachSounds.Length > 0 && NameNPC != "")
                speachAudio.PlayOneShot(speachSounds[WhoSpeaker(x)]);

            yield return new WaitForSeconds(.03f);
        }
        IsPrintingPhrase = false;
        if (!CloseButton.activeSelf)
        {
            DialogAnswerButton1.SetActive((true));
            DialogAnswerButton2.SetActive((true));
        }

        int WhoSpeaker(char c)
        {
            if (NameNPC == "") { return 0; }
            if (c == '-')
            {
                speakerBuffer.Clear();
                lastSpeaker = 0;
                return lastSpeaker;
            }

            if (speakerBuffer.Count == NameNPC.Length)
            {
                speakerBuffer.Dequeue();
            }
            speakerBuffer.Enqueue(c);

            if (speakerBuffer.Count == NameNPC.Length)
            {
                string currentWindow = new string(speakerBuffer.ToArray());
                if (currentWindow == NameNPC)
                {
                    lastSpeaker = 1;
                    return lastSpeaker;
                }
            }
            return lastSpeaker;
        }

    }

    private void PlayButtonClickSound()
    {
        if (clickAudio != null)
        {
            clickAudio.Play();
        }
    }

    public void OnFirstAnswerClicked()
    {
        PlayButtonClickSound();

        if (!IsPrintingPhrase)
        {
            var ans = CurrentDialog.Answer1;
            DialogResult++;

            if (CurrentDialog.ReactToAnswer1 != null)
            {
                CurrentDialog = CurrentDialog.ReactToAnswer1;
                StartCoroutine(SpellPhrase(ans + '\n' + CurrentDialog.Question));
            }
            else
            {

                StartCoroutine(SpellPhrase(CurrentDialog.Answer1));
                DialogAnswerButton1.SetActive(false);
                DialogAnswerButton2.SetActive(false);


                SaveKarma();
                CloseButton.SetActive(true);

            }


            if (CurrentDialog.Answer1 != "" && CurrentDialog.Answer2 != "")
            {
                DialogAnswer1.GetComponent<TMP_Text>().text = CurrentDialog.Answer1;
                DialogAnswer2.GetComponent<TMP_Text>().text = CurrentDialog.Answer2;
            }
            else
            {

                DialogAnswerButton1.SetActive(false);
                DialogAnswerButton2.SetActive(false);

                SaveKarma();
                CloseButton.SetActive(true);

            }


        }

    }
    public void OnSecondAnswerClicked()
    {
        PlayButtonClickSound();

        if (!IsPrintingPhrase)
        {
            var ans = CurrentDialog.Answer2;
            DialogResult--;


            if (CurrentDialog.ReactToAnswer2 != null)
            {
                CurrentDialog = CurrentDialog.ReactToAnswer2;
                StartCoroutine(SpellPhrase(ans + '\n' + CurrentDialog.Question));
            }
            else
            {
                StartCoroutine(SpellPhrase(CurrentDialog.Answer2));
                DialogAnswerButton1.SetActive(false);
                DialogAnswerButton2.SetActive(false);

                SaveKarma();
                CloseButton.SetActive(true);
            }
            if (CurrentDialog.Answer1 != "" && CurrentDialog.Answer2 != "")
            {
                DialogAnswer1.GetComponent<TMP_Text>().text = CurrentDialog.Answer1;
                DialogAnswer2.GetComponent<TMP_Text>().text = CurrentDialog.Answer2;
            }
            else
            {

                DialogAnswerButton1.SetActive(false);
                DialogAnswerButton2.SetActive(false);

                SaveKarma();
                CloseButton.SetActive(true);


            }
        }


    }


    void SaveKarma()
    {

        if (PlayerPrefs.HasKey("KarmaState"))
        {
            PlayerPrefs.SetInt("KarmaState", PlayerPrefs.GetInt("KarmaState") + DialogResult);

        }
        else
        {
            PlayerPrefs.SetInt("KarmaState", 50);


        }


    }

    public void CloseDialogWindow()
    {
        PlayButtonClickSound();
        DialogWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }

}
