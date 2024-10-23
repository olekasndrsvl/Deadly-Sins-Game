using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroSceneSubtitles : MonoBehaviour
{
    public GameObject FinallTitles;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartTitles()
    {
        FinallTitles.SetActive(true);
    }
    public void SunTitlesEnded()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
