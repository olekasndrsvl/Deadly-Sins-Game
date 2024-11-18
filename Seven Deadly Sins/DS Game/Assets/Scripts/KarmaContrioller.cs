using TMPro;
using UnityEngine;

public class KarmaContrioller : MonoBehaviour
{
    public GameObject TextKarma;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // PlayerPrefs.DeleteAll();

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("KarmaState"))
        {
            TextKarma.GetComponent<TMP_Text>().text = $"Карма: {PlayerPrefs.GetInt("KarmaState")}";
        }
        else
        {
           
            TextKarma.GetComponent<TMP_Text>().text = $"Карма: {50}";

        }
    }
}
