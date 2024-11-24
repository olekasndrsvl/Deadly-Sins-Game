using UnityEditor.Build;
using UnityEngine;

public class QueueTrigger : MonoBehaviour
{
    public GameObject interactButton; // ������ �� ������
    public GameObject dialogueBox;    // ������ �� ���������� ����
    private Collider2D Collider;

    void Start()
    {
        // �������� ������ � ������ ��� ������
        interactButton.SetActive(false);
        dialogueBox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Collider = other;
        // ���� ����� ������ � �������
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(true); // ���������� ������
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // ���� ����� ������� �� ��������
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(false); // �������� ������
        }
    }

    public void OnDialogueButtonWithPlayer()
    {

    }
}