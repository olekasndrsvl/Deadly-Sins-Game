using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnim : MonoBehaviour
{
    public GameObject ObjectToDestroyOnAnimEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void DestroyObject()
    {
        ObjectToDestroyOnAnimEvent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
