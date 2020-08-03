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

    [SerializeField]
    private GameObject joystickDialog = null;

    private bool isDialogActive;

    public bool IsDialogActive {
        get {
            return this.isDialogActive;
        }
        set {
            this.isDialogActive = value;
        }
    }
    
    void Start() {
        instance = this;
        if (Application.platform == RuntimePlatform.Android) {
            this.joystickDialog.SetActive(true);
        } else {
            this.joystickDialog.SetActive(false);
        }
    }

    void Update() {
        
    }
}
