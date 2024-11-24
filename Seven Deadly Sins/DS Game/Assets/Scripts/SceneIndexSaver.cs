using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneIndexSaver : MonoBehaviour
{
    void Start()
    {
     PlayerPrefs.SetInt("LastScene",SceneManager.GetActiveScene().buildIndex);   
    }
}
