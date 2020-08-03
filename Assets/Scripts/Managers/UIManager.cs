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
    }

    [SerializeField]
    private GameObject joystickDialog = null;

    private bool isDialogActive = false;

    public bool IsDialogActive {
        get {
            return this.isDialogActive;
        }
        set {
            this.isDialogActive = value;
        }
    }
    
    void Start() {
        if (Application.platform == RuntimePlatform.Android) {
            this.joystickDialog.SetActive(true);
            Cursor.visible = false;
        } else {
            this.joystickDialog.SetActive(true);
            Cursor.visible = true;
        }
    }

    void Update() {
        
    }
}
