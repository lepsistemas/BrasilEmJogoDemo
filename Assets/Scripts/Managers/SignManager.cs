using UnityEngine;
using UnityEngine.UI;

public class SignManager : MonoBehaviour {

    private static SignManager instance;

    public static SignManager Instance {
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

    void Start() {
    }

    public void ShowSign(string sign) {
        UIManager.Instance.DialogBox.TitleBox.gameObject.SetActive(false);
        UIManager.Instance.DialogBox.MessageBox.gameObject.SetActive(true);
        UIManager.Instance.DialogBox.gameObject.SetActive(true);
        UIManager.Instance.DialogBox.Message.text = sign;
    }

    public void HideSign() {
        UIManager.Instance.DialogBox.TitleBox.gameObject.SetActive(false);
        UIManager.Instance.DialogBox.MessageBox.gameObject.SetActive(false);
        UIManager.Instance.DialogBox.gameObject.SetActive(false);
        UIManager.Instance.DialogBox.Message.text = null;
    }
}
