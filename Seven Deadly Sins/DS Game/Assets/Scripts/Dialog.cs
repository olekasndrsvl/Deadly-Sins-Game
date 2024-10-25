using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;

using UnityEngine;

[Serializable]
public class DialogData // класс диалога рекурсивно определенный
{
    public string Question { get; set; }
    public string Answer1 { get; set; }
    public string Answer2 { get; set; }
    public DialogData ReactToAnswer1 { get; set; }
    public DialogData ReactToAnswer2 { get; set; }
    public DialogData(string question, string answer1, string answer2, DialogData reactToAnswer1, DialogData reactToAnswer2) : this(question, answer1, answer2)
    {
        Question = question;
        Answer1 = answer1;
        Answer2 = answer2;
        ReactToAnswer1 = reactToAnswer1;
        ReactToAnswer2 = reactToAnswer2;
    }

    public DialogData(string question,string answer1, string answer2)
    {
        Question = question;
        Answer1 = answer1;
        Answer2 = answer2;
    }
}


public class Dialog : MonoBehaviour
{
    private bool IsPrintingPhrase = false;
    public int DialogResult;
    public string ResultOfJson;
    public TextAsset DialogFile;
    // need link to text gameobject
    public GameObject DialogQuestion;
    public GameObject DialogAnswer1;
    public GameObject DialogAnswer2;
    public int AmountOfCharsWhichAreDisplayedAtPresent=100;

    //пример создания цепочки диалога
    DialogData p1 = new DialogData(
        "Данте: Ты справился унынием! Но это было лишь одно из семи испытаний.",
        "-Да, старец я усвоил жизненный урок",
        "-Ты мне будешь указывать старик!?", 
            new DialogData(
            "Данте: Ты молодец, тебе осталось все 6 испытаний до полного очищения", 
            "-Ясно", 
            "-Понятно"),
            new DialogData(
            "Данте: Ах ты, грязый щенок, не зря ты здесь оказался! Но ничего скоро научишься манерам!", 
            null, 
            null));
   
    //Переменная для отслеживания развилки диалога
    DialogData CurrentDialog;

    IEnumerator RunningCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        

        DialogQuestion.GetComponent<TMP_Text>().text = "";
       
        //Установка стартового диалога
        CurrentDialog = p1;
        RunningCoroutine = SpellPhrase(p1.Question);
        StartCoroutine(RunningCoroutine);
        
        DialogAnswer1.GetComponent<TMP_Text>().text = p1.Answer1;
        DialogAnswer2.GetComponent<TMP_Text>().text = p1.Answer2;
       
      

    }

    void Cleaner()
    {
        var s = DialogQuestion.GetComponent<TMP_Text>().text;
        var a = s.Split('\n',StringSplitOptions.RemoveEmptyEntries);
        if(a.Length>4 || s.Length > 100)
        {
            DialogQuestion.GetComponent<TMP_Text>().text = a.Last() + '\n';
        }

    }

    // печать по-буквенно
    IEnumerator SpellPhrase(string s)
    {
        Cleaner();
        IsPrintingPhrase = true;
        var sb = new StringBuilder(DialogQuestion.GetComponent<TMP_Text>().text);
        foreach(var x in s+'\n')
        {
            sb.Append(x);
            DialogQuestion.GetComponent<TMP_Text>().text = sb.ToString();
            yield return new WaitForSeconds(.05f);
        }
        IsPrintingPhrase = false;
    }


    public void OnFirstAnswerClicked()
    {
        if(!IsPrintingPhrase) 
        {
        var ans = CurrentDialog.Answer1;
        DialogResult++;
       
        if (CurrentDialog.ReactToAnswer1 != null)
        {
            CurrentDialog = CurrentDialog.ReactToAnswer1;
            StartCoroutine(SpellPhrase(ans+'\n'+CurrentDialog.Question));
        }
        else
        {
            StartCoroutine(SpellPhrase(CurrentDialog.Answer1));
        }
        DialogAnswer1.GetComponent<TMP_Text>().text = CurrentDialog.Answer1;
        DialogAnswer2.GetComponent<TMP_Text>().text = CurrentDialog.Answer2;

        }
        
    }
    public void OnSecondAnswerClicked()
    {
        if (!IsPrintingPhrase)
        {
        var ans = CurrentDialog.Answer2;
        DialogResult--;
       

        if (CurrentDialog.ReactToAnswer2 != null)
        {
            CurrentDialog = CurrentDialog.ReactToAnswer2;
            StartCoroutine(SpellPhrase(ans+'\n'+CurrentDialog.Question));
        }
        else
        {
            StartCoroutine(SpellPhrase(CurrentDialog.Answer2));
        }
        DialogAnswer1.GetComponent<TMP_Text>().text = CurrentDialog.Answer1;
        DialogAnswer2.GetComponent<TMP_Text>().text = CurrentDialog.Answer2;
        }
       

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
