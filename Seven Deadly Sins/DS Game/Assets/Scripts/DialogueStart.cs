using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueWindow; // —сылка на готовый объект DialogueWindow

    public void StartDialogue()
    {
        if (dialogueWindow != null)
        {
            dialogueWindow.SetActive(true); // ¬ключаем окно диалога
        }
    }
}