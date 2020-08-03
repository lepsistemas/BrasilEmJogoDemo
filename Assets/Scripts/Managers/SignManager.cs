﻿using UnityEngine;
using UnityEngine.UI;

public class SignManager : MonoBehaviour {

    private static SignManager instance;

    public static SignManager Instance {
        get {
            return instance;
        }
    }

    [SerializeField]
    private GameObject dialogBox = null;

    [SerializeField]
    private Text message = null;
    
    void Start() {
        instance = this;
    }

    void Update() {
        
    }

    public void ShowSign(string sign) {
        this.dialogBox.SetActive(true);
        this.message.text = sign;
        UIManager.Instance.IsDialogActive = true;
    }

    public void HideSign() {
        this.dialogBox.SetActive(false);
        this.message.text = null;
        UIManager.Instance.IsDialogActive = false;
    }

    public bool IsDialogBoxActivated() {
        return this.dialogBox != null && this.dialogBox.activeInHierarchy;
    }
}
