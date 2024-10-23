using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingSceneChange : MonoBehaviour
{

    public void ChangeScene(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber, LoadSceneMode.Single);
    }


}

