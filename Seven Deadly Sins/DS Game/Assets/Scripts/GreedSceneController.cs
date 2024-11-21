using UnityEngine;

public class GreedSceneController : MonoBehaviour
{
    public GameObject DialogWindow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogWindow.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
