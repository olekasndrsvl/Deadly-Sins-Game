using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Скорость движения NPC
    public float minDistance = 1f; // Минимальное расстояние для движения
    public float maxDistance = 3f; // Максимальное расстояние для движения
    public float minWaitTime = 0.5f; // Минимальное время ожидания
    public float maxWaitTime = 0.6f; // Максимальное время ожидания
    public float maxOffsetFromStart = 3f; // Максимальное удаление от начальной точки

    private float targetDistance;
    private Vector3 startPosition; 
    private Vector3 targetPosition; 
    private bool isWaiting = false;
    public Animator animator;

    void Start()
    {
        startPosition = transform.position;
        SetNewTarget();
    }

    void Update()
    {
        if (!isWaiting)
        {
            // Двигаем NPC к целевой позиции
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            FlipTowardsTarget();

            // Если NPC достиг целевой позиции, начинаем ожидание
            Debug.Log("remainig distance "+Vector3.Distance(transform.position, targetPosition));
            if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
            {
                StartCoroutine(WaitAndSetNewTarget());
            }
        }
    }

    void SetNewTarget()
    {
        animator.SetBool("IsWalking", true);
        // Выбираем случайное расстояние в пределах minDistance и maxDistance
        targetDistance = Random.Range(minDistance, maxDistance);

        // Случайно определяем направление движения (влево или вправо)
        if (Random.value > 0.5f)
        {
            targetPosition = startPosition + Vector3.right * targetDistance;
            Debug.Log("Move right "+targetDistance);
        }
        else
        {
            targetPosition = startPosition + Vector3.left * targetDistance;
            Debug.Log("Move left "+targetDistance);
        }

        // Проверяем, чтобы целевая позиция не выходила за пределы maxOffsetFromStart
        if (Vector3.Distance(targetPosition, startPosition) > maxOffsetFromStart)
        {
            // Если вышли за пределы, корректируем позицию
            targetPosition = startPosition + (targetPosition - startPosition).normalized * maxOffsetFromStart;
        }
    }

    IEnumerator WaitAndSetNewTarget()
    {
        isWaiting = true;
        animator.SetBool("IsWalking", false);

        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(waitTime);

        SetNewTarget();
        isWaiting = false;
    }
    void FlipTowardsTarget()
    {
        if (targetPosition.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (targetPosition.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}