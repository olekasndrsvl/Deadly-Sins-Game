using System.Collections;
using UnityEngine;

public class PersonInQueue:MonoBehaviour
{
    public bool IsPaused = false;
    Rigidbody2D person;
    public Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        person=GetComponent<Rigidbody2D>();

        GameObject queueSoundObject = GameObject.Find("QueueSound");
        if (queueSoundObject != null)
        {
            audioSource = queueSoundObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                //Debug.LogError("На объекте QueueSound нет компонента AudioSource!");
            }
        }
        else
        {
           // Debug.LogError("Объект QueueSound не найден в сцене!");
        }

        StartCoroutine(movement());
    }
    IEnumerator movement()
    {
       
       while (true)
       {
            if (!IsPaused)
            {
                if (animator != null)
                {
                    animator.SetBool("IsWalking", true);
                }

                person.linearVelocity = new Vector2(4, 0);
                yield return new WaitForSeconds(.5f);
                if (animator != null)
                {
                    animator.SetBool("IsWalking", false);
                }

                PlayStepSound();
            }
            Debug.Log(IsPaused);
            yield return new WaitForSeconds(10f);
            
       }
        
    }
    private void PlayStepSound()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
    private void Update()
    {
        
    }
}
