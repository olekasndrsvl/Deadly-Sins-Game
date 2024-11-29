using UnityEngine;

public class QueueTrigger : MonoBehaviour
{
    bool IsinTrigger = false;
    public GameObject interactButton; // ������ �� ������
    public GameObject dialogueBox;    // ������ �� ���������� ����
    public Collider2D Collider;

    void Start()
    {
        // �������� ������ � ������ ��� ������
        interactButton.SetActive(false);
      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Collider = other;
        // ���� ����� ������ � �������
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(true); // ���������� ������
        }

        IsinTrigger = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
      //  Collider = null;
        // ���� ����� ������� �� ��������
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(false); // �������� ������
        }
        IsinTrigger=false;
    }

   
}