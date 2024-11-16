using UnityEngine;

using System.Collections;

public class SpriteAnimationOnApproach : MonoBehaviour
{         
    public float animationSpeed = 0.2f;   
    public string playerTag = "Player";   
    public Animator animator;
    private Coroutine animationCoroutine; 

    private void Start()
    {
       animator=GetComponent<Animator>();
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogWarning("Игрок вошел в триггер");
        if (other.CompareTag(playerTag))
        {
            
            animator.enabled = true;
        }
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.LogWarning("Игрок вышел из триггера");
        if (other.CompareTag(playerTag))
            {

                animator.enabled = false;
            }
    
    }

   
}