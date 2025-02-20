using UnityEngine;
using UnityEngine.EventSystems;

public class Moving : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool move;
    private float startPosX;
    private float startPosY;
    private Vector2 touchPos;

    public Vector2 targetPosition = new Vector2(0, 0);
    public float threshold = 0.1f;

    void Start()
    {
        move = false;
    }

    void Update()
    {
        if (move)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        touchPos = touch.position;
                        this.transform.localPosition = new Vector2(touchPos.x - startPosX, touchPos.y - startPosY);
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        move = false;
                        break;
                }
            }

            if (Vector2.Distance(this.transform.localPosition, targetPosition) < threshold)
            {
                move = false;
                this.transform.localPosition = targetPosition;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        move = true;
        startPosX = eventData.position.x - this.transform.localPosition.x;
        startPosY = eventData.position.y - this.transform.localPosition.y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        move = false;
    }
}