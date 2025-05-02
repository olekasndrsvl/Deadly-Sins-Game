using UnityEngine;

public class PrideUnWear : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Close()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
