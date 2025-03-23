using UnityEngine;

public class DistributionSceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TipConrtrollerScript.TipsTextMessage = "Ты оказался в аду, Морт, и выйти отсюда ты сможешь, только пройдя все котлы!";
        TipConrtrollerScript.IsNewTextAdded = true;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(PlayerPrefs.GetInt("KarmaState", 0));
    }
}
