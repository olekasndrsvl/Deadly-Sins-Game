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


}

