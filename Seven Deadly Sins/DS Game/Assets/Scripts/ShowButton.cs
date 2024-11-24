using UnityEditor.Build;
using UnityEngine;

public class QueueTrigger : MonoBehaviour
{
    public GameObject interactButton; // Ссылка на кнопку
    public GameObject dialogueBox;    // Ссылка на диалоговое окно
    private Collider2D Collider;

    void Start()
    {
        // Скрываем кнопку и диалог при старте
        interactButton.SetActive(false);
        dialogueBox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Collider = other;
        // Если игрок входит в триггер
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(true); // Показываем кнопку
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Если игрок выходит из триггера
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(false); // Скрываем кнопку
        }
    }

    public void OnDialogueButtonWithPlayer()
    {

    }
}