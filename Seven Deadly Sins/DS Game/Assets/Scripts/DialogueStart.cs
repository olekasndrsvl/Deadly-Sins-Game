using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueWindow; // ������ �� ������� ������ DialogueWindow

    public void StartDialogue()
    {
        if (dialogueWindow != null)
        {
            dialogueWindow.SetActive(true); // �������� ���� �������
        }
    }
}