using System.Collections;
using UnityEngine;

public class PersonInQueue:MonoBehaviour
{
    public Rigidbody2D person;

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
                Debug.LogError("На объекте QueueSound нет компонента AudioSource!");
            }
        }
        else
        {
            Debug.LogError("Объект QueueSound не найден в сцене!");
        }

        StartCoroutine(movement());
    }
    IEnumerator movement()
    {
        while (true)
        {
            person.linearVelocity = new Vector2(4,0);
            PlayStepSound();
            yield return new WaitForSeconds(2f);
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
