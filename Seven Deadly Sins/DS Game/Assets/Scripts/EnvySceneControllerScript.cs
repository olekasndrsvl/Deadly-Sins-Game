using UnityEngine;

public class EnvySceneControllerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TipConrtrollerScript.TipsTextMessage = "Пришло время сразиться с лучшей версией себя, Морт!";
        TipConrtrollerScript.IsNewTextAdded = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
