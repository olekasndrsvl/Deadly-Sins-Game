using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = System.Random;

public class DragAndDropText : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    public Vector3 startPosition;
    public AudioClip[] SelectSounds;

   
    private void Awake()
    {
        // Получаем RectTransform текстового объекта
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.transform.position;
        canvas= GetComponentInParent<Canvas>();
    }

    // Вызывается, когда начинается перетаскивание
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Отключаем Raycast Target, чтобы предотвратить конфликты с другими UI-элементами
        GetComponent<Graphic>().raycastTarget = false;
    }

    // Вызывается во время перетаскивания
    public void OnDrag(PointerEventData eventData)
    {
        // Перемещаем текстовый объект в соответствии с движением мыши/касания
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }

    // Вызывается, когда перетаскивание завершено
    public void OnEndDrag(PointerEventData eventData)
    {
        // Включаем Raycast Target обратно
        AudioSource audioSource = GetComponentInParent<AudioSource>();

        var randomSound = UnityEngine.Random.Range(0, SelectSounds.Length);
        audioSource.PlayOneShot(SelectSounds[randomSound]);
        GetComponent<Graphic>().raycastTarget = true;
    }

    public void Reset()
    {
        var r = new Random();
        rectTransform.transform.position = new Vector3(r.Next(Screen.width/5,Screen.width/3),r.Next(Screen.height/5,(int)(Screen.height-rectTransform.transform.localScale.y)), 0);
    }
}