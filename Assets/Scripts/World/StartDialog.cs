using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour {

    private bool activated;

    private bool action;

    void Start() {
        this.activated = false;
    }

    void Update() {
        if (this.action && this.activated && !DialogManager.Instance.IsDialogBoxActivated()) {
            this.action = false;
        }
    }

    private void FireButton1() {
        this.action = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            this.activated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            this.activated = false;
        }
    }


}
