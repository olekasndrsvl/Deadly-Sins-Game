using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingSceneChange : MonoBehaviour
{
    public void ChangeSceneAndSave()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
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

}

