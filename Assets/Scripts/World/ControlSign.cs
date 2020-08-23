using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSign : MonoBehaviour {

    [SerializeField]
    private string sign = null;

    private bool canActivate;

    void Update() {
        if (this.canActivate) {
            if (ControllerManager.Instance.PrimaryButtonFired) {
                if (!UIManager.Instance.DialogBox.gameObject.activeInHierarchy) {
                    SignManager.Instance.ShowSign(this.sign);
                } else {
                    SignManager.Instance.HideSign();
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
