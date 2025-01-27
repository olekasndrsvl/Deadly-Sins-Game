using System.Collections;
using TMPro;
using UnityEngine;

public class BetterVersionOfMprtScript : MonoBehaviour
{
    public Animator MortAnim;
    public bool IsPaused = false;
    public string Deb;
    public int HealthPoints;
    public GameObject EnemyBody;
    Rigidbody2D RgEnemy;
    public int DamageAmount = 10;
    public GameObject HP_text;
    bool IsAtacking = false;
   
    int Rage = 4;

    public AudioClip[] HitSounds;
    private AudioSource audioSource;

    private int lastSoundIndex = -1;

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        Deb = collision.tag+" ";
        if (collision.CompareTag("Player"))
        {
         
            if (!IsAtacking && collision!= null)
            {
               
                StartCoroutine(Atack(collision));
            }
          
        }
     
    }
    private void PlayRandomHitSound()
    {
        if (HitSounds.Length > 0 && audioSource != null)
        {
            int newSoundIndex;
            do
            {
                newSoundIndex = Random.Range(0, HitSounds.Length);
            } while (newSoundIndex == lastSoundIndex && HitSounds.Length > 1);

            lastSoundIndex = newSoundIndex;
            audioSource.PlayOneShot(HitSounds[newSoundIndex]);
        }
    }

    IEnumerator PlayAttackAnim()
    {
        MortAnim.SetBool("IsFighting", true);
        yield return new WaitForSeconds(1f);
        MortAnim.SetBool("IsFighting", false);
        
    }
    IEnumerator Atack(Collider2D collision)
    {
        IsAtacking = true;
       
        int i = Random.Range(0, 2); 
        if (i == 1)
        {
            PlayRandomHitSound();
            StartCoroutine(PlayAttackAnim());
            collision.gameObject.transform.Find("HitBox").GetComponent<EnvylLevelPlayerHitBox>().HealthPoints -= DamageAmount;
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityY = Rage;
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityX = -Rage;
        }

        yield return new WaitForSeconds(1f);
       
        IsAtacking = false;
    }

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        RgEnemy = EnemyBody.GetComponent<Rigidbody2D>();
        HealthPoints = 100;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource не найден на объекте врага!");
        }

    }
  
  
    // Update is called once per frame
    void Update()
    {
        HP_text.GetComponent<TMP_Text>().text = HealthPoints.ToString();
        
    }
}


