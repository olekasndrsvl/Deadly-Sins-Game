using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;

public class DialogData // класс диалога рекурсивно определенный
{
    public string Question { get; set; }
    public string Answer1 { get; set; }
    public string Answer2 { get; set; }

    public DialogData ReactToAnswer1 { get; set; }
    public DialogData ReactToAnswer2 { get; set; }
    
    public DialogData(string question,string answer1, string answer2)
    {
        Question = question;
        Answer1 = answer1;
        Answer2 = answer2;
    }
}


public class Dialog : MonoBehaviour
{
    // need link to text gameobject
    public GameObject DialogQuestion;
    public GameObject DialogAnswer1;
    public GameObject DialogAnswer2;
    public int AmountOfCharsWhichAreDisplayedAtPresent=100;

    //пример создания цепочки диалога
    DialogData p1 = new DialogData(
        "Данте: Ты справился унынием! Но это было лишь одно из семи испытаний.\n",
        "-Да, старец я усвоил жизненный урок\n",
        "-Ты мне будешь указывать старик!?\n");
    DialogData p2 = new DialogData(
        "Данте: Ты молодец, тебе осталось все 6 испытаний до полного очищения\n", "-Ясно", "-Понятно"); // если ветвление не планируется, то пишем вместо ответов нулевую ссылку null 
    DialogData p3 = new DialogData(
        "Данте: Ах ты, грязый щенок, не зря ты здесь оказался! Но ничего скоро научишься манерам!\n", null, null);
    
    //Переменная для отслеживания развилки диалога
    DialogData CurrentDialog;

    IEnumerator RunningCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        DialogQuestion.GetComponent<TMP_Text>().text = "";
        //Связывание диалогов
        p1.ReactToAnswer1 = p2;
        p1.ReactToAnswer2 = p3;
        //Установка старотового диалога
        CurrentDialog = p1;
        RunningCoroutine = PrintDialogQuestion(p1.Question);
        StartCoroutine(RunningCoroutine);
      //  StopCoroutine(RunningCoroutine);
        DialogAnswer1.GetComponent<TMP_Text>().text = p1.Answer1;
        DialogAnswer2.GetComponent<TMP_Text>().text = p1.Answer2;

        //DialogQuestion.GetComponent<TMP_Text>().text = "Данте: Привет! \n";
        //DialogAnswer1.GetComponent<TMP_Text>().text = "Answer1";
        //DialogAnswer2.GetComponent<TMP_Text>().text = "Answer2";
        //StartCoroutine(PrintDialogQuestion("\"Данте: Ты справился унынием! Но это было лишь одно из семи испытаний. \r \nМорт: (выберите ответ)\""));

    }

    //Coroutine для печати диалога построчно
    IEnumerator PrintDialogQuestion(string question)
    {
        StringBuilder s = new StringBuilder(DialogQuestion.GetComponent<TMP_Text>().text);
        if (s.Length > AmountOfCharsWhichAreDisplayedAtPresent)
        {
            DialogQuestion.GetComponent<TMP_Text>().text = DialogQuestion.GetComponent<TMP_Text>().text.Split('\n',System.StringSplitOptions.RemoveEmptyEntries).Last()+'\n';
            s = new StringBuilder(DialogQuestion.GetComponent<TMP_Text>().text);
        }
       
        var a = question.Split('\n',System.StringSplitOptions.RemoveEmptyEntries);
       
        foreach(var b in a)
        {
            s.Append(b).Append('\n');
            DialogQuestion.GetComponent<TMP_Text>().text = s.ToString();
            yield return new WaitForSeconds(3f);
        }

      

    }

    public void OnFirstAnswerClicked()
    {
        
        StartCoroutine(PrintDialogQuestion(CurrentDialog.Answer1));

        if(CurrentDialog.ReactToAnswer1 != null)
        {
            CurrentDialog = CurrentDialog.ReactToAnswer1;
            
            RunningCoroutine = PrintDialogQuestion(CurrentDialog.Question);
            StartCoroutine(RunningCoroutine);
      
          
        }
        else
        {

        }
        DialogAnswer1.GetComponent<TMP_Text>().text = CurrentDialog.Answer1;
        DialogAnswer2.GetComponent<TMP_Text>().text = CurrentDialog.Answer2;

    }
    public void OnSecondAnswerClicked()
    {
        RunningCoroutine = PrintDialogQuestion(CurrentDialog.Answer2);
        StartCoroutine(RunningCoroutine);

        if(CurrentDialog.ReactToAnswer2 != null)
        {
            CurrentDialog = CurrentDialog.ReactToAnswer2;

            RunningCoroutine = PrintDialogQuestion(CurrentDialog.Question);
            StartCoroutine(RunningCoroutine);

          
        }
        else
        {
            
        }
        DialogAnswer1.GetComponent<TMP_Text>().text = CurrentDialog.Answer1;
        DialogAnswer2.GetComponent<TMP_Text>().text = CurrentDialog.Answer2;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
