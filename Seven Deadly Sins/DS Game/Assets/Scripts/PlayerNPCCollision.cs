using UnityEngine;
using UnityEngine.UI;

public class PlayerNPCCollision : MonoBehaviour
{
    public GameObject interactionPanel;
    public Button moveForwardButton; 
    public float moveDistance = 2f;
    public Transform player;

    private bool isCollidingWithNPC = false;

    public WrathSceneController controller;

    private void OnEnable()
    {
        HitBox.onNPCdamaged += ChekHit;
    }

    private void OnDisable()
    {
        HitBox.onNPCdamaged -= ChekHit;
    }
    private void Start()
    {
        // Скрываем панель при старте игры
        if (interactionPanel != null)
        {
            interactionPanel.SetActive(false);
        }

        // Назначаем метод для обработки нажатия кнопки
        if (moveForwardButton != null)
        {
            moveForwardButton.onClick.AddListener(MovePlayerForward);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, столкнулся ли игрок с NPC
        if (collision.CompareTag("NPC"))
        {
            isCollidingWithNPC = true;

            if (interactionPanel != null)
            {
                interactionPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Если игрок вышел из зоны столкновения с NPC, скрываем панель
        if (collision.CompareTag("NPC"))
        {
            isCollidingWithNPC = false;
            if (interactionPanel != null)
            {
                interactionPanel.SetActive(false);
            }
        }
    }

    private void MovePlayerForward()
    {
        float direction = player.localScale.x > 0 ? 1 : -1;

        Vector3 newPosition = player.position + Vector3.right * direction * moveDistance;

        player.position = newPosition;

        if (interactionPanel != null)
        {
            interactionPanel.SetActive(false);
        }
    }

    private void ChekHit()
    {
        if (isCollidingWithNPC) controller.Lose();
    }
}