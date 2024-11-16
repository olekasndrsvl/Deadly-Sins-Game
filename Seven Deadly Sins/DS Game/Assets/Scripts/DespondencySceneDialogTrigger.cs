using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DespondencySceneDialogTrigger : MonoBehaviour
{
    public GameObject DialogWindow;
    //public GameObject ButtonExit;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("IsDespondencySceneDone", 0);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            DialogWindow.SetActive(true);
           // ButtonExit.SetActive(true);
        }
        
    }
    public void OnOutButtonClicked()
    {
        StartCoroutine(ChangeSceneCoroutine(1.5f));
        PlayerPrefs.SetInt("IsDespondencySceneDone", 1);

    }

    private IEnumerator ChangeSceneCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
