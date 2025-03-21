using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string correctObjectTag; // Тег правильного объекта
    public bool isOccupied = false; // Флаг, указывающий, занят ли слот
    public GameObject currentItem; // Текущий объект в слоте
   

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && !isOccupied)
        {
            // Устанавливаем позицию перетаскиваемого объекта на позицию слота
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = 
            GetComponent<RectTransform>().anchoredPosition;

            // Запоминаем текущий объект в слоте
            currentItem = eventData.pointerDrag;
            isOccupied = true;

            // Уведомляем SlotCounter о том, что объект попал в слот
            SlotCounter.Instance.IncrementTotalCount();

            // Проверяем, является ли объект правильным
            if (currentItem.CompareTag(correctObjectTag))
            {
                SlotCounter.Instance.IncrementCorrectCount();
            }
        }
    }

    // Вызывается, когда объект покидает слот
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isOccupied && eventData.pointerDrag == currentItem)
        {
            // Объект покинул слот
            isOccupied = false;

            // Уведомляем SlotCounter о том, что объект убран из слота
            SlotCounter.Instance.DecrementTotalCount();

            // Если объект был правильным, уменьшаем счетчик правильных объектов
            if (currentItem.CompareTag(correctObjectTag))
            {
                SlotCounter.Instance.DecrementCorrectCount();
            }

            currentItem = null;
        }
    }

    // Этот метод нужен для реализации интерфейса, но мы его не используем
    public void OnPointerEnter(PointerEventData eventData) { }
}