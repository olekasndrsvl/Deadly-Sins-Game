using UnityEngine;

public class DistributionSceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TipConrtrollerScript.TipsTextMessage = "�� �������� � ���, ����, � ����� ������ �� �������, ������ ������ ��� �����!";
        TipConrtrollerScript.IsNewTextAdded = true;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(PlayerPrefs.GetInt("KarmaState", 0));
    }
}
