using Unity.VisualScripting;
using UnityEngine;

public class DeleteQueue:MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name!="Player")
        Destroy(collision.gameObject);
    }

}
