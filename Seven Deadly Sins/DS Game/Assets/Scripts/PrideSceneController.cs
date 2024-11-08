using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrideSceneController : MonoBehaviour
{
    public GameObject tips;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

    // Update is called once per frame
    void Update()
    {
        tips.GetComponent<TMP_Text>().text = "Это будет тяжелая борьба с самим собой Морт!";
    }
}
