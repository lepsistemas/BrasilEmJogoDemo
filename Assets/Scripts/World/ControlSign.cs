using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSign : MonoBehaviour {

    [SerializeField]
    private string sign = null;

    private bool canActivate;
    
    void Start() {
    }

    void Update() {
        if (this.canActivate) {
            if (ControllerManager.Instance.Button1Fired) {
                if (!SignManager.Instance.IsDialogBoxActivated()) {
                    SignManager.Instance.ShowSign(this.sign);
                    GameManager.Instance.Player.CanMove = false;
                } else {
                    SignManager.Instance.HideSign();
                    GameManager.Instance.Player.CanMove = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            this.canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            this.canActivate = false;
        }
    }
}
