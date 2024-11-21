using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class OnTriggerSceneLoad : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject LevelChoice;
    public TextMeshProUGUI LevelDesciption;
    public int NumberOfLoadingScene;
    static string CurrentSceneToLoad;
    public void OnTriggerEnter2D(Collider2D other)
    {
        LevelChoice.SetActive(true);
        switch (NumberOfLoadingScene)
        {
            case 3:
                LevelDesciption.text = "Вы хотите перейти на уровень \"Гнев\"?";
                CurrentSceneToLoad = "WrathScene";
                break;
            case 4:

                break;
            case 5:
                CurrentSceneToLoad = "WrathScene";
                LevelDesciption.text = "Вы хотите перейти на уровень \"Гнев\"?";
                break;
            case 6:
                CurrentSceneToLoad = "VanityScene";
                LevelDesciption.text = "Вы хотите перейти на уровень \"Тщеславие\"?";
                break;
            case 7:
                CurrentSceneToLoad = "PrideScene";
                LevelDesciption.text = "Вы хотите перейти на уровень \"Гордыня\"?";
                break;
            case 8:
                CurrentSceneToLoad = "BoastScene";
                LevelDesciption.text = "Вы хотите перейти на уровень \"Хваставство\"?";
                break;
            case 9:
                CurrentSceneToLoad = "EnvyScene";
                LevelDesciption.text = "Вы хотите перейти на уровень \"Зависть\"?";
                break;
            case 10:
                CurrentSceneToLoad = "GreedScene";
                LevelDesciption.text = "Вы хотите перейти на уровень \"Жадность\"?";
                break;
            default:
                CurrentSceneToLoad = "OutroScene";
                LevelDesciption.text = "Вы хотите перейти к финалу игры?";
                break;
        }

    }
    public void OnConfirmButtonClicked()
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene(CurrentSceneToLoad, LoadSceneMode.Single);
    }
    public void Disagreement()
    {
        LevelChoice.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
