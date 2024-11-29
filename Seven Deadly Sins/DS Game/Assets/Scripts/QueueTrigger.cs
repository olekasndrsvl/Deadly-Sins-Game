using UnityEngine;

public class QueueTrigger : MonoBehaviour
{
    bool IsinTrigger = false;
    public GameObject interactButton; // Ссылка на кнопку
    public GameObject dialogueBox;    // Ссылка на диалоговое окно
    public Collider2D Collider;

    void Start()
    {
        // Скрываем кнопку и диалог при старте
        interactButton.SetActive(false);
      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Collider = other;
        // Если игрок входит в триггер
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(true); // Показываем кнопку
        }

        IsinTrigger = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
      //  Collider = null;
        // Если игрок выходит из триггера
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(false); // Скрываем кнопку
        }
        IsinTrigger=false;
    }

   
}