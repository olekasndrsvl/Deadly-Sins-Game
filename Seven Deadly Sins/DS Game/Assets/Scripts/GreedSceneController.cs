using UnityEngine;
using UnityEngine.SceneManagement;

public class GreedSceneController : MonoBehaviour
{
    public GameObject DialogWindow;
    public GameObject LoadingScreen;
    public void OnEndOfDanteDialog()
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene("DistributionScene", LoadSceneMode.Single);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogWindow.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
