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

    private float speedFactor = 1f;

    public float SpeedFactor {
        get {
            return this.speedFactor;
        }
        set {
            this.speedFactor = value;
        }
    }

    void Start() {
        instance = this;
    }

    void Update() {
        this.x = Input.GetAxisRaw("Horizontal") + this.joystick.Horizontal;
        this.y = Input.GetAxisRaw("Vertical") + this.joystick.Vertical;

        if (Input.GetButton("Fire1") || this.fire1Button.Pressed) {
            OnFireButton1Pressed?.Invoke();
        }

        if (Input.GetButton("Fire3") || this.fire3Button.Pressed) {
            this.speedFactor = 2f;
        } else {
            this.speedFactor = 1f;
        }
    }

    public delegate void OnFireButton1Handler();

    public event OnFireButton1Handler OnFireButton1Pressed;
}
