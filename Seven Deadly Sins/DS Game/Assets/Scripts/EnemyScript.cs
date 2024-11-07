using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public string Deb;
    public int HealthPoints;
    public GameObject EnemyBody;
    Rigidbody2D RgEnemy;
    public int DamageAmount = 10;
    public GameObject HP_text;
    bool IsAtacking = false;
    bool IsWalking = false;
    int Rage = 4;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        Deb = collision.tag+" ";
        if (collision.CompareTag("Player"))
        {
         
            if (!IsAtacking)
            {
              
                StartCoroutine(Atack(collision));
            }
          
        }
     
    }

    IEnumerator Atack(Collider2D collision)
    {
        IsAtacking= true;
        int i = Random.Range(0, 2); 
        if (i == 1)
        { 
            collision.gameObject.transform.Find("HitBox").GetComponent<HitBox>().HealthPoints -= DamageAmount;
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityY = Rage*2;
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
      
    }
    public float speed = 2f; // Скорость движения NPC
    public float rightLimit = 15f; // Правая граница
    public float leftLimit = 10f; // Левая граница

    private int direction = 1;
    // Update is called once per frame
    void Update()
    {
        // Двигаем NPC
        EnemyBody.transform.position += Vector3.right * direction * speed * Time.deltaTime;

        // Проверяем границы и меняем направление
        if (EnemyBody.transform.position.x >= rightLimit)
        {
            direction = -1; // Меняем направление на влево
        }
        else if (EnemyBody.transform.position.x <= leftLimit)
        {
            direction = 1; // Меняем направление на вправо
        }


        HP_text.GetComponent<TMP_Text>().text = HealthPoints.ToString();
        if (HealthPoints <= 0)
        {
            Destroy(this);
        }
        
    }
}
