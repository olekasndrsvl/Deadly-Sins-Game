using UnityEngine;
using UnityEngine.SceneManagement;

public class GreedSceneController : MonoBehaviour
{
    public GameObject GreedDialog;
    public GameObject LoadingScreen;
    public GameObject WinningDialog;
    public GameObject LosingDialog;
    public GameObject LevelPreview;
    int winningThreshold = 3;

    private void Start()
    {
        if (PlayerPrefs.GetInt("ISGreedPreviewDisplayed", 0) == 1)
        {
            LevelPreview.SetActive(false);
        }

        PlayerPrefs.SetInt("ISGreedPreviewDisplayed", 1);
        

        TipConrtrollerScript.TipsTextMessage = "Пришло время поговорить в с глазу на глаз со своей жадностью, Морт!";
        TipConrtrollerScript.IsNewTextAdded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GreedDialog.SetActive(true);
    }
    public void EndOfGreed()
    {
        GreedDialog.SetActive(false);
        if (GreedDialog.GetComponent<Dialog>().DialogResult >= winningThreshold)
        {
            WinningDialog.SetActive(true);
        }
        else
        {
            LosingDialog.SetActive(true);
        }
    }
    public void OnEndButtonClicked()
    {
        WinningDialog.SetActive(false);
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene("DistributionScene", LoadSceneMode.Single);
    }

    public void RestartOnLose()
    {
        PlayerPrefs.Save();
        LosingDialog.SetActive(false);
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}