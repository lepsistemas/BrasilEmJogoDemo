using UnityEngine;

public class ActionButton : MonoBehaviour {

    private bool pressed;

    public bool Pressed {
        get {
            return this.pressed;
        }
        set {
            this.pressed = value;
        }
    }
    
    public void OnMouseDown() {
        this.pressed = true;
    }
}
