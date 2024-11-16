using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotImplmentedButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("DistributionScene", LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
