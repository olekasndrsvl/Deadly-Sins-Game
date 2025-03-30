using TMPro;
using UnityEngine;

public class EnvySceneControllerScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public GameObject levelpreview;
    public GameObject StartDialog;
    public GameObject FinalDialog;
    public GameObject LoseDialog;
    public TMP_Text HP_Player;
    public TMP_Text HP_Enemy;
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

    public void onLevelEnd()
    {
        PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) + 1);
    }
    // Update is called once per frame
    void Update()
    {
        HP_Player.text = "Здоровье: "+Player.GetComponent<PlayerAttack>().health.ToString();
        HP_Enemy.text= Enemy.GetComponent<Enemy>().health.ToString();
        
        if (Player.GetComponent<PlayerAttack>().health <= 0 && FinalDialog.activeSelf == false)
        {
            LoseDialog.SetActive(true);
            Player.GetComponent<PlayerAttack>().health = 0;
            Enemy.GetComponent<global::Enemy>().IsPaused=true;
            Enemy.GetComponent<BetterVersionOfMortControllerScript>().IsPaused = true;
        }

        if (Enemy.GetComponent<Enemy>().health <= 0)
        {
            levelphase++;
            Enemy.GetComponent<Enemy>().health = 0;
            Enemy.GetComponent<global::Enemy>().IsPaused=true;
        }

        if (levelphase >= 1)
        {
            FinalDialog.SetActive(true);
        }
    }
}
