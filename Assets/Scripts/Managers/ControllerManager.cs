using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {

    private static ControllerManager instance;

    public static ControllerManager Instance {
        get {
            return instance;
        }
    }

    [SerializeField]
    private Joystick joystick = null;

    [SerializeField]
    private JoystickButton fire1Button = null;

    [SerializeField]
    private JoystickButton fire3Button = null;

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

    private bool button1Fired;

    public bool Button1Fired {
        get {
            return this.button1Fired;
        }
        set {
            this.button1Fired = value;
        }
    }

    private bool button3Fired;

    public bool Button3Fired {
        get {
            return this.button3Fired;
        }
        set {
            this.button3Fired = value;
        }
    }

    private void Awake() {
        if (instance != null && instance != this && this.gameObject != null) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    void Update() {
        this.x = Input.GetAxisRaw("Horizontal") + this.joystick.Horizontal;
        this.y = Input.GetAxisRaw("Vertical") + this.joystick.Vertical;

        if (Input.GetButtonDown("Fire1") || this.fire1Button.Pressed) {
            this.button1Fired = true;
        } else {
            this.button1Fired = false;
        }

        if (Input.GetButton("Fire3") || this.fire3Button.Pressed) {
            this.button3Fired = true;
        } else {
            this.button3Fired = false;
        }
    }
}
