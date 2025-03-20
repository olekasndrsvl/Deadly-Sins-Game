using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropText : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;

    private void Awake()
    {
        // Получаем RectTransform текстового объекта
        rectTransform = GetComponent<RectTransform>();
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
        rectTransform.anchoredPosition += eventData.delta;
    }

    // Вызывается, когда перетаскивание завершено
    public void OnEndDrag(PointerEventData eventData)
    {
        // Включаем Raycast Target обратно
        GetComponent<Graphic>().raycastTarget = true;
    }
}