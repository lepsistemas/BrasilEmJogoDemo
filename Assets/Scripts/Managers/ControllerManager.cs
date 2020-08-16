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

    private bool cancelButtonFired;

    public bool CancelButtonFired {
        get {
            return this.cancelButtonFired;
        }
        set {
            this.cancelButtonFired = value;
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
        this.x = Input.GetAxisRaw("Horizontal");
        this.y = Input.GetAxisRaw("Vertical");
        if (this.virtualJoystick != null && this.virtualJoystick.Pad != null) {
            this.x += this.virtualJoystick.Pad.Horizontal;
            this.y += this.virtualJoystick.Pad.Vertical;
        }

        bool primaryButtonPressed = this.virtualJoystick != null && this.virtualJoystick.PrimaryButton != null && this.virtualJoystick.PrimaryButton.Pressed;
        if (Input.GetButtonDown("Fire1") || primaryButtonPressed) {
            this.primaryButtonFired = true;
            if (this.virtualJoystick != null && this.virtualJoystick.PrimaryButton != null) {
                this.virtualJoystick.PrimaryButton.Pressed = false;
            }
        } else {
            this.primaryButtonFired = false;
        }

        bool secondaryButtonHolding = this.virtualJoystick != null && this.virtualJoystick.SecondaryButton != null && this.virtualJoystick.SecondaryButton.Holding;
        if (Input.GetButton("Fire3") || secondaryButtonHolding) {
            this.secondaryButtonFired = true;
        } else {
            this.secondaryButtonFired = false;
        }

        if (Input.GetButtonDown("Cancel")) {
            this.cancelButtonFired = true;
        } else {
            this.cancelButtonFired = false;
        }
    }
}
