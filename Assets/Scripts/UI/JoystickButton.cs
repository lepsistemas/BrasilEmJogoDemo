using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private bool holding;

    public bool Holding {
        get {
            return this.holding;
        }
        set {
            this.holding = value;
        }
    }
    
    void Start() {
        
    }

    void Update() {
        
    }

    public void OnPointerDown(PointerEventData eventData) {
        this.holding = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        this.holding = false;
    }
}
