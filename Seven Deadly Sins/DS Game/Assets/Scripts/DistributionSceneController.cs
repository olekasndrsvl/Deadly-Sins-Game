using UnityEngine;

public class DistributionSceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (PlayerPrefs.GetInt("LevelsCompleted",0))
        {
            case 1:
                TipConrtrollerScript.TipsTextMessage =
                    "Ты оказался в аду, Морт, и выйти отсюда ты сможешь, только пройдя все котлы!";
                TipConrtrollerScript.IsNewTextAdded = true;
                break;
            case 2:
                if (PlayerPrefs.GetInt("KarmaState", 0) < 57)
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "Ты кажется не усвоил урок!? Теперь тебе придется снова окунуться в этот котел!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                    PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) - 1);
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "Я вижу ты хорошо начал, так держать,Морт!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("KarmaState", 0) < 58)
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "Ты кажется не усвоил урок!? Теперь тебе придется снова окунуться в этот котел!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                    PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) - 1);
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "Отличная работа,Морт! Не каждому под силу одолеть Жадность!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("KarmaState", 0) < 60)
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "Ты кажется не усвоил урок!? Теперь тебе придется снова окунуться в этот котел!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                    PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) - 1);
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "Это было сложно расставить приоритеты, но ты справился!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                break;
            
            case 5:
                if (PlayerPrefs.GetInt("KarmaState", 0) < 90)
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "Ты кажется не усвоил урок!? Теперь тебе придется снова окунуться в этот котел!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                    PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) - 1);
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "Хороший рассказ,Морт! Тебе бы в ораторы...";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                break;
            case 6:
                if (PlayerPrefs.GetInt("KarmaState", 0) < 110)
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "Ты кажется не усвоил урок!? Теперь тебе придется снова окунуться в этот котел!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                    PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) - 1);
                }
                else
                {
                    TipConrtrollerScript.TipsTextMessage =
                        "Умение сдерживаться тебе пригодиться!";
                    TipConrtrollerScript.IsNewTextAdded = true;
                }
                break;
            case 7:
                TipConrtrollerScript.TipsTextMessage =
                    "Ты прошел путь очищения, сын мой! Проследуй к выходу из ада, он прямо за тобой!";
                TipConrtrollerScript.IsNewTextAdded = true;
                break;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(PlayerPrefs.GetInt("KarmaState", 0));
       //Debug.Log(PlayerPrefs.GetInt("LevelsCompleted", 0) );
    }
}
