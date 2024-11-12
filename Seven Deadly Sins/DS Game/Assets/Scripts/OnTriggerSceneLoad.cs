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
                SceneManager.LoadScene("WrathScene", LoadSceneMode.Single);
                break;
            case 6:
                SceneManager.LoadScene("VanityScene", LoadSceneMode.Single);
                break;
            case 7:
                SceneManager.LoadScene("PrideScene", LoadSceneMode.Single);
                break;
            case 8:
                SceneManager.LoadScene("BoastScene", LoadSceneMode.Single);
                break;
            case 9:
                SceneManager.LoadScene("EnvyScene", LoadSceneMode.Single);
                break;
            case 10:
                SceneManager.LoadScene("GreedScene", LoadSceneMode.Single);
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
