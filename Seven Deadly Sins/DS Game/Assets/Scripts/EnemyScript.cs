using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public string Deb;
    public int HealthPoints;
    public int DamageAmount = 10;
    public GameObject HP_text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Deb = collision.tag;
        if (collision.CompareTag("Player"))
        {
           if(Random.Range(0,1)==1)
                collision.gameObject.transform.Find("HitBox").GetComponent<HitBox>().HealthPoints-=DamageAmount;
            
          
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthPoints = 100;
    }

    // Update is called once per frame
    void Update()
    {
        HP_text.GetComponent<TMP_Text>().text = HealthPoints.ToString();
        if (HealthPoints <= 0)
        {
            Destroy(this);
        }
        
    }
}
