using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeScript : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
