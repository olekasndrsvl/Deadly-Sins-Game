using UnityEngine;

public class ActivateUnWearPreview : MonoBehaviour
{
    public GameObject UnwearPreview;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void DislayPreview()
    {
        UnwearPreview.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
