using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;


public class Enemy : MonoBehaviour
{
    
    public float timeBetweenAttacks;
    public float startTimeBetweenAttacks;
    public int damageAmount;
    public float stopTime;
    public float startstopTime;
    public GameObject deathEffect;
    
    public PlayerAttack Player;
    private Animator enemyAnimator;
    
    public int health = 100;
    public float speed = 1f; // Скорость движения NPC
    public float rightLimit = 15f; // Правая граница
    public float leftLimit = 10f; // Левая граница
    
    public bool isAttacking =false;
    public Transform EnemyBody;
    public  bool IsPaused;

    public bool isNeedAutoMove = true;
    public AudioClip[] HitSounds;
    private AudioSource audioSource;
    private int lastSoundIndex = -1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Obsolete("Obsolete")]
    void Start()
    { 
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource не найден на объекте врага!");
        }
        EnemyBody = GetComponent<Transform>();
        enemyAnimator=GetComponent<Animator>();
        Player = FindObjectOfType<PlayerAttack>();
      
    }

    // Update is called once per frame
      
   

    private int direction = 1;
    
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            enemyAnimator.SetBool("IsDied",true);
            isAttacking = false;
        }
        else
        {
            enemyAnimator.SetBool("IsDied",false);
        }
        
        
        
        
        
        if(isNeedAutoMove)
        {
            if (!(IsPaused || isAttacking))
            {

                // Двигаем NPC
                if (stopTime <= 0)
                {
                    EnemyBody.transform.position += Vector3.right * (direction * speed * Time.deltaTime);

                    // Проверяем границы и меняем направление
                    if (EnemyBody.transform.position.x >= rightLimit)
                    {
                        //yield return new WaitForSeconds(1f);
                        direction = -1; // Меняем направление на влево
                    }
                    else if (EnemyBody.transform.position.x <= leftLimit)
                    {
                        direction = 1; // Меняем направление на вправо
                        //yield return new WaitForSeconds(1f);
                    }
                }
                else
                {

                    stopTime -= Time.deltaTime;
                }

            }
        }
    }


    private void PlayRandomHitSound()
    {
        var random = new Random();
        if (HitSounds.Length > 0 && audioSource != null)
        {
            int newSoundIndex;
            do
            {
                
                newSoundIndex = random.Next(0, HitSounds.Length);
            } while (newSoundIndex == lastSoundIndex && HitSounds.Length > 1);

            lastSoundIndex = newSoundIndex;
            audioSource.PlayOneShot(HitSounds[newSoundIndex]);
        }
    }
   
    
    private void OnTriggerStay2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player")&& !IsPaused)
        {
            Debug.Log(collision.gameObject.name);
            if (timeBetweenAttacks <= 0)
            {
                enemyAnimator.SetTrigger("Fighting");
                isAttacking = true;
                PlayRandomHitSound();
                Instantiate(deathEffect, transform.position, Quaternion.identity);
            }
            else
            {
                timeBetweenAttacks -= Time.deltaTime;
            }
          
        }
     
    }
    public void TakeDamage(int damage)
    {
        stopTime = startstopTime;
        direction *= -1;
        health -= Player.damageAmount;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }

    public void OnEnemyAttack()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        
        Player.health-=damageAmount;
        timeBetweenAttacks = startTimeBetweenAttacks;
        isAttacking=false;
        
    }
}
