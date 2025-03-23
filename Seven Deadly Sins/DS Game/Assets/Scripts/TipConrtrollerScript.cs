using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class TipConrtrollerScript : MonoBehaviour
{
    public Animator DantesIconAnimator;
    public Animator DantesFaceAnimator;
    public GameObject TipsWindow;
    public GameObject TipsText;
    Animator TipsWindowAnimator;
    public static string TipsTextMessage;
    public static bool IsNewTextAdded;
    public bool IsTipShowed{get
        {
            return IsTipsWindowActive;
        }
    }
    bool IsTipsWindowActive = false;

    // Start is called before the first frame update
    void Start()
    {   
        TipsWindowAnimator = TipsWindow.GetComponent<Animator>();

        TipsText.GetComponent<TMP_Text>().text = TipsTextMessage;
    }
    public void OnTipsClicked()
    {
        IsTipsWindowActive = !IsTipsWindowActive;

        if(IsTipsWindowActive)
        {
            TipsOpen();
        }
        else
        {
            TipsClose();
        }

        //TipsWindow.SetActive(IsTipsWindowActive);
        ////TipsWindowAnimator.SetBool("", true);
        //DantesIconAnimator.SetBool("OnTipsIconClicked", !DantesIconAnimator.GetBool("OnTipsIconClicked"));
        

        //TipsWindowAnimator.SetBool("TipsWindowOpened", !TipsWindowAnimator.GetBool("TipsWindowOpened"));

        //DantesFaceAnimator.SetBool("DanteIsTalking", !DantesFaceAnimator.GetBool("DanteIsTalking"));

    }
    void TipsOpen()
    {
        TipsWindow.SetActive(IsTipsWindowActive);
        //TipsWindowAnimator.SetBool("", true);
        DantesIconAnimator.SetBool("OnTipsIconClicked", true);


        TipsWindowAnimator.SetBool("TipsWindowOpened", true);

        DantesFaceAnimator.SetBool("DanteIsTalking", true);
    }
    void TipsClose()
    {
        TipsWindow.SetActive(IsTipsWindowActive);
        //TipsWindowAnimator.SetBool("", true);
        DantesIconAnimator.SetBool("OnTipsIconClicked", false);


        TipsWindowAnimator.SetBool("TipsWindowOpened", false);

        DantesFaceAnimator.SetBool("DanteIsTalking", false);
    }
   

    IEnumerator SpellTip(string tip)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < tip.Length-1; i++)
        {
            sb.Append(tip[i]);
            TipsText.GetComponent<TMP_Text>().text = sb.ToString();
            yield return new WaitForSeconds(.05f);
        }
        yield return new WaitForSeconds(3f);
        TipsClose();
        IsTipsWindowActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsNewTextAdded)
        {
            OnTipsClicked();
            IsNewTextAdded = false;
            StartCoroutine(SpellTip(TipsTextMessage));
           
        }
    }
}
