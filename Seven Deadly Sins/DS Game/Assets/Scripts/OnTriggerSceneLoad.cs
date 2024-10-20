using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerSceneLoad : MonoBehaviour
{
    public int NumberOfLoadingScene;

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (NumberOfLoadingScene)
        {
            case 3:
                SceneManager.LoadScene("DespondencyScene", LoadSceneMode.Single);
                break;
            case 4:
                
                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            case 8:

                break;
            default:
                SceneManager.LoadScene("OutroScene",LoadSceneMode.Single);
                break;
        }

        
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
