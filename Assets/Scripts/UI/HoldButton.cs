using UnityEngine;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private bool holding;

    public bool Holding {
        get {
            return this.holding;
        }
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        this.holding = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        this.holding = false;
    }
}
