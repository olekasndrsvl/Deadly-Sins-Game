using System.Collections;
using UnityEngine;

public class PersonInQueue:MonoBehaviour
{
    public Rigidbody2D person;
    private void Start()
    {
        person=GetComponent<Rigidbody2D>();
        StartCoroutine(movement());
    }
    IEnumerator movement()
    {
        while (true)
        {
            person.linearVelocity = new Vector2(4,0);
            yield return new WaitForSeconds(10f);
        }
    }
    private void Update()
    {
        
    }
}
