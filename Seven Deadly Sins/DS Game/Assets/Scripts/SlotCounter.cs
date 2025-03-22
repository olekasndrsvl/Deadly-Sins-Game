using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlotCounter : MonoBehaviour
{
    public static SlotCounter Instance; // Синглтон для удобного доступа к счетчику
    public GameObject[] slots;
    public GameObject[] slotspos;
    public int totalCount = 0; // Общее количество объектов в слотах
    public int correctCount = 0; // Количество правильных объектов в слотах

    private void Awake()
    {
        // Реализация синглтона
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Метод для увеличения общего счетчика
    public void IncrementTotalCount()
    {
        totalCount++;
        Debug.Log("Объект добавлен в слот. Общий счет: " + totalCount);

        // Проверяем, достиг ли общий счетчик значения 3
        if (totalCount >= 3)
        {
            CheckWinCondition();
        }
    }

    // Метод для уменьшения общего счетчика
    public void DecrementTotalCount()
    {
        if (totalCount > 0)
        {
            totalCount--;
            Debug.Log("Объект убран из слота. Общий счет: " + totalCount);
        }
    }

    // Метод для увеличения счетчика правильных объектов
    public void IncrementCorrectCount()
    {
        correctCount++;
        Debug.Log("Правильный объект добавлен в слот. Счет правильных: " + correctCount);

        // Проверяем, достиг ли общий счетчик значения 3
        if (totalCount >= 3)
        {
            CheckWinCondition();
        }
    }

    // Метод для уменьшения счетчика правильных объектов
    public void DecrementCorrectCount()
    {
        if (correctCount > 0)
        {
            correctCount--;
            Debug.Log("Правильный объект убран из слота. Счет правильных: " + correctCount);
        }
    }

    // Проверка условий победы
    private void CheckWinCondition()
    {
        if (correctCount >= 3)
        {
            Debug.Log("Все объекты правильные! Переход на сцену победы...");
            VanitySceneController.IncLevelphase();
            //LoadScene(2); // Переход на сцену победы (индекс 2)
        }
        else
        {
            Debug.Log("Не все объекты правильные. Переход на сцену поражения...");
                // LoadScene(3); // Переход на сцену поражения (индекс 3)
                foreach(GameObject x in slots)
                {
                    
                    x.gameObject.GetComponent<DragAndDropText>().Reset();
                }

                foreach (var x in slotspos)
                {
                    x.GetComponent<Slot>().isOccupied=false;
                    x.GetComponent<Slot>().currentItem=null;
                }
                correctCount = 0;
                totalCount = 0;
                Debug.Log("Счет правильных: " + correctCount);
                Debug.Log("Общий счет: " + totalCount);
                VanitySceneController.ShowLoseTip();
        }
    }

    public void Reset()
    {
        foreach(GameObject x in slots)
        {
                    
            x.gameObject.GetComponent<DragAndDropText>().Reset();
        }

        foreach (var x in slotspos)
        {
            x.GetComponent<Slot>().isOccupied=false;
            x.GetComponent<Slot>().currentItem=null;
        }
        correctCount = 0;
        totalCount = 0;
    }

    // Метод для перехода на другую сцену
    private void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); // Загружаем сцену по индексу
    }
}