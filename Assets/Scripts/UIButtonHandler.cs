using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public BallController ballController;
    public string action; // "left", "right", "jump"

    public void OnPointerDown(PointerEventData eventData)
    {
        if (action == "left") ballController.MoveLeft();
        else if (action == "right") ballController.MoveRight();
        else if (action == "jump") ballController.Jump();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (action == "left" || action == "right") ballController.StopMoving();
    }
}
