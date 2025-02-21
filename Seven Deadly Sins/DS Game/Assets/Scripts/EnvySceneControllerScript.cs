using TMPro;
using UnityEngine;

public class EnvySceneControllerScript : MonoBehaviour
{
    public GameObject Enemy;
    int enemyhp = 0;

    private int levelphase = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TipConrtrollerScript.TipsTextMessage = "Пришло время сразиться с лучшей версией себя, Морт!";
        TipConrtrollerScript.IsNewTextAdded = true;
        
    }

    void SwitchPhaseOf()
    {
        levelphase++;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.GetComponent<BetterVersionOfMprtScript>().HealthPoints <= 0)
        {
            levelphase++;
        }
    }
}
