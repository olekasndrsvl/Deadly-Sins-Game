using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeScript : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
       // PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ForDespondencySceneLoad()
    {
      
        if (PlayerPrefs.HasKey("IsDespondencySceneDone"))
        {
            if (PlayerPrefs.GetInt("IsDespondencySceneDone") == 1)
            {
                StartCoroutine(ChangeSceneCoroutine(2, 1.5f));
            }
            else
            {
                StartCoroutine(ChangeSceneCoroutine(4, 1.5f));
            }
          
        }
        else
        {
            StartCoroutine(ChangeSceneCoroutine(4, 1.5f));
        }
       
    }


    public void ChangeSceneWithDelay(int sceneNumber)
    {
        StartCoroutine(ChangeSceneCoroutine(sceneNumber, 1.5f));
    }

    private IEnumerator ChangeSceneCoroutine(int sceneNumber, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
    }

    public void ChangeScene(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber,LoadSceneMode.Single);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
