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
<<<<<<< HEAD
            yield return new WaitForSeconds(10f);
=======
            yield return new WaitForSeconds(2f);
>>>>>>> 5fc69b9a16c2bfb65443ce495b3ea3253f7185e2
        }
    }
    private void Update()
    {
        
    }
}
