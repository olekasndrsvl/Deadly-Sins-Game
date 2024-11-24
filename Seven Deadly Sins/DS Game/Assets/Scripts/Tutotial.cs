using System;
using System.Collections;
using System.Text;
using UnityEngine;
using TMPro;

public class Tutotial : MonoBehaviour
{
    public string phrase;
    private Coroutine tutorialCoroutine;
    public TipConrtrollerScript tips;
    public string key;
    public bool dante;
    private void Awake()
    {
        if (PlayerPrefs.GetInt(key) == 1)
        {
            gameObject.SetActive(false);
            
            if(dante) TipConrtrollerScript.TipsTextMessage = phrase;
        }
        else
        {
            PlayerPrefs.SetInt(key, 1);
        }
    }

    public void DantePhrases()
    {
        tutorialCoroutine = StartCoroutine(SpellPhrase(phrase));
    }
    IEnumerator SpellPhrase(string s)
    {
        yield return new WaitForSeconds(1f);
        tips.TipsText.GetComponent<TMP_Text>().text = "";
        var sb = new StringBuilder("");
        foreach(var x in s+'\n')
        {
            sb.Append(x);
            tips.TipsText.GetComponent<TMP_Text>().text = sb.ToString();
            yield return new WaitForSeconds(.05f);
        }
    }
}
