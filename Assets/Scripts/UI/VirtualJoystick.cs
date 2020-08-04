using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour {

    private FixedJoystick pad;

    public FixedJoystick Pad {
        get {
            return this.pad;
        }
    }

    private ActionButton primaryButton;

    public ActionButton PrimaryButton {
        get {
            return this.primaryButton;
        }
    }

    private HoldButton secondaryButton;

    public HoldButton SecondaryButton {
        get {
            return this.secondaryButton;
        }
    }
    
    void Start() {
        this.pad = FindObjectOfType<FixedJoystick>();
        this.primaryButton = FindObjectOfType<ActionButton>();
        this.secondaryButton = FindObjectOfType<HoldButton>();
    }

    void Update() {
    }
}
