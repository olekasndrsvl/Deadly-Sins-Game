using System.Collections;
using TMPro;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    
    public string Deb;
    public int HealthPoints;
    public int DamageAmount=10;
    public GameObject HP_text;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Deb = collision.tag;
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.transform.Find("HitBox").GetComponent<EnemyScript>().HealthPoints-=DamageAmount;
        }
    }
    IEnumerator Hint(float sec)
    {

        transform.localPosition = new Vector3(5, 0, 0);
        yield return new WaitForSeconds(sec);
        transform.localPosition = new Vector3(0,0,0);
    }
    public void OnActionButtonClicked()
    {
      
        StartCoroutine(Hint(.5f));
      

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       HealthPoints = 100;

    }
    // Update is called once per frame
    void Update()
    {
        HP_text.GetComponent<TMP_Text>().text = "��������: "+HealthPoints.ToString();

        //if (HealthPoints <= 0)
        //{

        //    //TODO: activate dialog
          
        //}
    }
}
