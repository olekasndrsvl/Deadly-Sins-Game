using UnityEngine;

public class NPCTrigger2D : MonoBehaviour
{
    public int dres = 2;
    [Range(0f, 1f)]
    public float disableChance = 0.5f;
    public Rigidbody2D rigitBody;
    public GameObject Dialog;
    public GameObject[] PersonInQue = new GameObject[6];

    private void Start()
    {
      rigitBody = transform.parent.gameObject.GetComponent<Rigidbody2D>();
  
    }

    void PauseAll()
    {
        for (int i = 0; i < PersonInQue.Length; i++)
        {
            PersonInQue[i].GetComponent<PersonInQueue>().IsPaused = !PersonInQue[i].GetComponent<PersonInQueue>().IsPaused;
        }
    }
    

    public void ActivateDialog() 
    {
        PauseAll();
        Dialog.SetActive(true);

    }

    public void OnCloseDialog()
    {
        Dialog.SetActive(false);
        PauseAll();
        if(Dialog.GetComponent<Dialog>().DialogResult == dres)
        {
            rigitBody.mass = 1.1f;
            GetComponent<QueueTrigger>().Collider.gameObject.transform.position += new Vector3(4, 0);
        }
       
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    //Debug.LogWarning("Is triggered");
    //    if (other.CompareTag("Player"))
    //    {
    //        float randomValue = Random.value;

    //        if (randomValue < disableChance)
    //        {
    //         
    //        }
    //        else
    //        {
    //            //Debug.Log("Капсульный коллайдер 2D не отключен для NPC " + gameObject.name);
    //        }
    //    }
    //}
}