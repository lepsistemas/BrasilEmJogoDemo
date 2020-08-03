using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    [HideInInspector]
    protected bool pressed;

    public bool Pressed {
        get {
            return this.pressed;
        }
        set {
            this.pressed = value;
        }
    }
    
    void Start() {
        
    }

    void Update() {
        
    }

    public void OnPointerDown(PointerEventData eventData) {
        this.Pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        this.Pressed = false;
    }
}
