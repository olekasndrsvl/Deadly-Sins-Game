using TMPro;
using UnityEngine;

public class EnvySceneControllerScript : MonoBehaviour
{
    public GameObject BetterVersionofMort;
    public GameObject Player;
    public GameObject Enemy;
    int enemyhp = 0;
    public GameObject levelpreview;
    public GameObject StartDialog;
    public GameObject FinalDialog;
    public GameObject LoseDialog;
    private int levelphase = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TipConrtrollerScript.TipsTextMessage = "Пришло время сразиться с лучшей версией себя, Морт!";
        TipConrtrollerScript.IsNewTextAdded = true;
        if (PlayerPrefs.GetInt("IsLevelPreviewDisplayed", 0) == 1)
        {
            levelpreview.SetActive(false);
            StartDialog.SetActive(false);
        }
        PlayerPrefs.SetInt("IsLevelPreviewDisplayed",1);
    }

   
    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<EnvylLevelPlayerHitBox>().HealthPoints <= 0)
        {
            LoseDialog.SetActive(true);
            BetterVersionofMort.GetComponent<BetterVersionOfMortControllerScript>().IsPaused = true;
        }

        if (Enemy.GetComponent<BetterVersionOfMprtScript>().HealthPoints <= 0)
        {
            levelphase++;
        }

        if (levelphase >= 1)
        {
            FinalDialog.SetActive(true);
        }
    }
}
