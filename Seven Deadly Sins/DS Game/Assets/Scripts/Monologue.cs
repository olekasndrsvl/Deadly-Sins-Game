using System;
using System.Collections;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

[Serializable]

public class Monologue : MonoBehaviour
{
    private bool isPrintingPhrase = false;
    public int dialogResult;

    public GameObject monologueText;
    public GameObject dialogWindow;
    public GameObject dialogAnswerButton1;
    public GameObject dialogAnswerButton2;
    public GameObject closeButton;

    public AudioSource clickAudio;
    public TypeMonologData currentMonologue;

    IEnumerator runningCoroutine;

    void Start()
    {
        // MonologueData monologue1 = new MonologueData
        // {
        //     text = "Пришло время мне рассказать о себе.",
        //     answer1 = "Рассказать какой вы крутой.",
        //     answer2 = "Рассказать историю из детства.",
        //     nextMonologue1 = new MonologueData
        //     {
        //         text = "Теперь то я расскажу о том, насколько я крут",
        //         answer1 = "Продолжить рассказывать.",
        //         answer2 = "Закончить разговор.",
        //         nextMonologue1 = new MonologueData
        //         {
        //             text = "Ты не выкупаешь, насколько я крут\r\nЯ так нравлюсь твоей лали, ха, она зовёт подруг\r\nКаждой суке дам по малли, нахуй нам не нужен клуб",
        //             answer1 = "Рассказать про клуб.",
        //             answer2 = "Закончить разговор.",
        //             nextMonologue1 = null,
        //             nextMonologue2 = null
        //         },
        //         nextMonologue2 = null
        //     },
        //     nextMonologue2 = new MonologueData
        //     {
        //         text = "Когда я был маленьким, я...",
        //         answer1 = "Был очень злым",
        //         answer2 = "Был достаточно милым парнем",
        //         nextMonologue1 = null,
        //         nextMonologue2 = null
        //     }
        //};

        //currentMonologue = monologue1;

        dialogAnswerButton1.transform.GetChild(0).GetComponent<TMP_Text>().text = currentMonologue.Answer1;
        dialogAnswerButton2.transform.GetChild(0).GetComponent<TMP_Text>().text = currentMonologue.Answer2;

        runningCoroutine = SpellPhrase(currentMonologue.Text);
        StartCoroutine(runningCoroutine);
    }

    void Cleaner()
    {
        var textComponent = monologueText.GetComponent<TMP_Text>();
        var text = textComponent.text;
        var lines = text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        // Limit to a maximum of 4 lines
        if (lines.Length > 4)
        {
            textComponent.text = string.Join("\n", lines.Skip(lines.Length - 4));
        }

        // Limit to a maximum of 100 characters
        if (text.Length > 100)
        {
            textComponent.text = text.Substring(text.Length - 100);
        }
    }

    IEnumerator SpellPhrase(string s)
    {
        Cleaner();
        isPrintingPhrase = true;
        dialogAnswerButton1.SetActive(false);
        dialogAnswerButton2.SetActive(false);
        var sb = new StringBuilder(monologueText.GetComponent<TMP_Text>().text);
        foreach (var x in s + '\n')
        {
            sb.Append(x);
            monologueText.GetComponent<TMP_Text>().text = sb.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        isPrintingPhrase = false;
        dialogAnswerButton1.SetActive(true);
        dialogAnswerButton2.SetActive(true);
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

        if (!isPrintingPhrase)
        {
            SaveKarma(true); // Add karma for the first answer
            if (currentMonologue.ReactToAnswer1 != null)
            {
                currentMonologue = currentMonologue.ReactToAnswer1;
                UpdateDialog();
            }
            else
            {
                dialogAnswerButton1.SetActive(false);
                dialogAnswerButton2.SetActive(false);
                closeButton.SetActive(true);
                //CloseDialogWindow();
            }
        }
    }

    public void OnSecondAnswerClicked()
    {
        PlayButtonClickSound();

        if (!isPrintingPhrase)
        {
            SaveKarma(false); // Subtract karma for the second answer
            if (currentMonologue.ReactToAnswer2 != null)
            {
                currentMonologue = currentMonologue.ReactToAnswer2;
                UpdateDialog();
            }
            else
            {
                dialogAnswerButton1.SetActive(false);
                dialogAnswerButton2.SetActive(false);
                closeButton.SetActive(true);
                //CloseDialogWindow();
            }
        }
    }

    private void UpdateDialog()
    {
        dialogAnswerButton1.transform.GetChild(0).GetComponent<TMP_Text>().text = currentMonologue.Answer1;
        dialogAnswerButton2.transform.GetChild(0).GetComponent<TMP_Text>().text = currentMonologue.Answer2;

        runningCoroutine = SpellPhrase(currentMonologue.Text);
        StartCoroutine(runningCoroutine);
    }

    public void CloseDialogWindow()
    {
        PlayButtonClickSound();
        dialogWindow.SetActive(false);
    }

    void SaveKarma(bool isFirstAnswer)
    {
        if (PlayerPrefs.HasKey("KarmaState"))
        {
            if (isFirstAnswer)
            {
                PlayerPrefs.SetInt("KarmaState", PlayerPrefs.GetInt("KarmaState") + 10); // Add karma
            }
            else
            {
                PlayerPrefs.SetInt("KarmaState", PlayerPrefs.GetInt("KarmaState") - 10); // Subtract karma
            }
        }
        else
        {
            PlayerPrefs.SetInt("KarmaState", 50); // Default karma
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}