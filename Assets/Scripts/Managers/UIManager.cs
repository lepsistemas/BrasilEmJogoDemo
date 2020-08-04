using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private static UIManager instance;

    public static UIManager Instance {
        get {
            return instance;
        }
    }

    private void Awake() {
        if (instance != null && instance != this && this.gameObject != null) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }

        this.gameStatus = GameObject.FindObjectOfType<GameStatus>();
        this.virtualJoystick = GameObject.FindObjectOfType<VirtualJoystick>();
        this.dialogBox = GameObject.FindObjectOfType<DialogBox>();

        if (Application.platform == RuntimePlatform.Android) {
            this.virtualJoystick.gameObject.SetActive(true);
        } else {
            this.virtualJoystick.gameObject.SetActive(false);
        }

        this.dialogBox.gameObject.SetActive(false);
    }

    private GameStatus gameStatus;

    private VirtualJoystick virtualJoystick;

    private DialogBox dialogBox;

    public DialogBox DialogBox {
        get {
            return this.dialogBox;
        }
    }
}
