using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = System.Random;


public class Enemy : MonoBehaviour
{
    public LayerMask PLayerMask;
    public Transform attackpos;
    public float attackrange;
    public float timeBetweenAttacks;
    public float startTimeBetweenAttacks;
    public int damageAmount;
    public float stopTime;
    public float startstopTime;
    public GameObject deathEffect;
    
    public PlayerAttack Player;
    private Animator enemyAnimator;
    
    public int health = 100;
    public float speed = 1f; // �������� �������� NPC
    public float rightLimit = 15f; // ������ �������
    public float leftLimit = 10f; // ����� �������
    
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
            Debug.LogError("AudioSource �� ������ �� ������� �����!");
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
            health = 0;
        }
        else
        {
            enemyAnimator.SetBool("IsDied",false);
        }
        
        
        var players = Physics2D.OverlapCircleAll(attackpos.position, attackrange,PLayerMask);

        if (players.Length > 0 && !IsPaused)
        {
           
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
        
        
        if(isNeedAutoMove)
        {
            if (!(IsPaused || isAttacking))
            {

                // ������� NPC
                if (stopTime <= 0)
                {
                    EnemyBody.transform.position += Vector3.right * (direction * speed * Time.deltaTime);

                    // ��������� ������� � ������ �����������
                    if (EnemyBody.transform.position.x >= rightLimit)
                    {
                        //yield return new WaitForSeconds(1f);
                        direction = -1; // ������ ����������� �� �����
                    }
                    else if (EnemyBody.transform.position.x <= leftLimit)
                    {
                        direction = 1; // ������ ����������� �� ������
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
           
        }
     
    }
    public void TakeDamage(int damage)
    {
        stopTime = startstopTime;
        direction *= -1;
        var r = new Random();
        health -= Player.damageAmount+r.Next(-5,5);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }

    public void OnEnemyAttack()
    {
        if(health>0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            Player.health -= damageAmount;
            timeBetweenAttacks = startTimeBetweenAttacks;
            isAttacking = false;
        }
        
    }
}
