using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
   
    public void ChangeSceneWithDelay(int sceneNumber)
    {
        StartCoroutine(ChangeSceneCoroutine(sceneNumber, 1.5f));
    }

    private IEnumerator ChangeSceneCoroutine(int sceneNumber, float delay)
    {
        yield return new WaitForSeconds(delay);  
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);  
    }

    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }

}