using System;
using UnityEngine;

public class WrathNPCLogic : MonoBehaviour
{
    bool IsinTrigger = false;
    public GameObject interactButton;
    public WrathSceneController controller;
    public Collider2D collider;
    private bool hasTalk;

    private void OnEnable()
    {
        HitBox.onNPCdamaged += ChekHit;
    }
    private void OnDisable()
    {
        HitBox.onNPCdamaged -= ChekHit;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&!hasTalk)
        {
            interactButton.SetActive(true);
            IsinTrigger = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(false);
            IsinTrigger = false;
        }
        
    }

    private void ChekHit()
    {
        if (IsinTrigger)
        {
            controller.Lose();
            collider.enabled = false;
            interactButton.SetActive(false);
        }
    }

    public void CloseButton()
    {
        hasTalk = true;
        interactButton.SetActive(false);
    }
}
