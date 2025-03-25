using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using System;
public class SpritesSorter : MonoBehaviour
{
    private bool trigger = false;
    private SpriteRenderer spriteRenderer;
    private int originalSortingOrder;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSortingOrder = spriteRenderer.sortingOrder;
        UpdateSortingOrder();
    }

    private void UpdateSortingOrder()
    {
        spriteRenderer.sortingOrder = originalSortingOrder + (trigger ? originalSortingOrder/System.Math.Abs(originalSortingOrder)*originalSortingOrder : 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name=="Feet_Position"){
            trigger = true;
           // gameObject.GetComponent<BoxCollider2D>().enabled = false;
            UpdateSortingOrder();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name=="Feet_Position"){
            trigger = false;
            //gameObject.GetComponent<BoxCollider2D>().enabled = true;
            UpdateSortingOrder();
        }
    }
}
