using UnityEngine;

public class NPCTrigger2D : MonoBehaviour
{
    [Range(0f, 1f)]
    public float disableChance = 0.5f;
    public Rigidbody2D rigitBody;

    private void Start()
    {
      rigitBody = transform.parent.gameObject.GetComponent<Rigidbody2D>();
  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogWarning("Is triggered");
        if (other.CompareTag("Player"))
        {
            float randomValue = Random.value;

            if (randomValue < disableChance)
            {
                rigitBody.mass = 1.1f;
                other.gameObject.transform.position += new Vector3(4, 0);
            }
            else
            {
                Debug.Log("Капсульный коллайдер 2D не отключен для NPC " + gameObject.name);
            }
        }
    }
}