using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipConrtrollerScript : MonoBehaviour
{
    public Animator DantesIconAnimator;
    public Animator DantesFaceAnimator;
    public GameObject TipsWindow;
    public GameObject TipsText;
    Animator TipsWindowAnimator;

    bool IsTipsWindowActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
        TipsWindowAnimator = TipsWindow.GetComponent<Animator>();

        TipsText.GetComponent<TMP_Text>().text = "Данте говорит:\n Привет! Я тебя не обижу иди ко мне!";
    }
    public void OnTipsClicked()
    {
        IsTipsWindowActive = !IsTipsWindowActive;
        TipsWindow.SetActive(IsTipsWindowActive);
        //TipsWindowAnimator.SetBool("", true);
        DantesIconAnimator.SetBool("OnTipsIconClicked", !DantesIconAnimator.GetBool("OnTipsIconClicked"));
        

        TipsWindowAnimator.SetBool("TipsWindowOpened", !TipsWindowAnimator.GetBool("TipsWindowOpened"));

        DantesFaceAnimator.SetBool("DanteIsTalking", !DantesFaceAnimator.GetBool("DanteIsTalking"));

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
