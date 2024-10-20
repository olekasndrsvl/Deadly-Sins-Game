using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerSceneLoad : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("DespondencyScene", LoadSceneMode.Single);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
