using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSign : MonoBehaviour {

    [SerializeField]
    private string sign = null;

    private bool activated;

    private bool action;
    
    void Start() {
        ControllerManager.Instance.OnFireButton1Pressed += this.FireButton1;
    }

    void Update() {
        if (this.activated) {
            ExecuteAfterTime();
        }
    }

    IEnumerator ExecuteAfterTime() {
        yield return new WaitForSeconds(500);

        if (this.action) {
            Debug.Log("Show");
            SignManager.Instance.ShowSign(this.sign);
        } else {
            Debug.Log("Hide");
            SignManager.Instance.HideSign();
        }
    }

    private void FireButton1() {
        this.action = !this.action;
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
