using UnityEngine;

public class ControllerManager : MonoBehaviour {

    private static ControllerManager instance;

    public static ControllerManager Instance {
        get {
            return instance;
        }
    }

    private float x;

    public float X {
        get {
            return this.x;
        }
        set {
            this.x = value;
        }
    }

    private float y;

    public float Y {
        get {
            return this.y;
        }
        set {
            this.y = value;
        }
    }

    private bool primaryButtonFired;

    public bool PrimaryButtonFired {
        get {
            return this.primaryButtonFired;
        }
        set {
            this.primaryButtonFired = value;
        }
    }

    private bool secondaryButtonFired;

    public bool SecondaryButtonFired {
        get {
            return this.secondaryButtonFired;
        }
        set {
            this.secondaryButtonFired = value;
        }
    }

    [SerializeField]
    private VirtualJoystick virtualJoystick = null;

    private void Awake() {
        if (instance != null && instance != this && this.gameObject != null) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    void Update() {
        this.x = Input.GetAxisRaw("Horizontal") + this.virtualJoystick.Pad.Horizontal;
        this.y = Input.GetAxisRaw("Vertical") + this.virtualJoystick.Pad.Vertical;

        if (Input.GetButtonDown("Fire1") || this.virtualJoystick.PrimaryButton.Pressed) {
            this.primaryButtonFired = true;
            this.virtualJoystick.PrimaryButton.Pressed = false;
        } else {
            this.primaryButtonFired = false;
        }

        if (Input.GetButton("Fire3") || this.virtualJoystick.SecondaryButton.Holding) {
            this.secondaryButtonFired = true;
        } else {
            this.secondaryButtonFired = false;
        }
    }
}
