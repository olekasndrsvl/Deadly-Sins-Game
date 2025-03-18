using UnityEngine;
using UnityEngine.SceneManagement;
public class WrathSceneController : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void Lose()
    {
        gameOverPanel.SetActive(true);
    }
    public void Replay()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
