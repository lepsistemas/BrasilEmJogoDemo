using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public static DialogManager instance;

    public static DialogManager Instance {
        get {
            return instance;
        }
    }

    [SerializeField]
    private GameObject dialogBox = null;

    [SerializeField]
    private GameObject titleBox = null;

    [SerializeField]
    private Text title = null;

    [SerializeField]
    private Text message = null;

    private Dialog[] dialogs;

    public Dialog[] Dialogs {
        set {
            this.dialogs = value;
        }
    }

    private int currentMessageIndex;

    private bool nextMessage;

    private bool isSign;

    void Start() {
        instance = this;

        this.currentMessageIndex = 0;
        ControllerManager.Instance.OnFireButton1Pressed += this.FireButton1;
        // this.dialogs = new Dialog[] {
        //     new Dialog("Pedro Álvares Cabral", "Ora pois, que desastre! Quebraste minha bússola!"),
        //     new Dialog("Pedro Álvares Cabral", "Agora como poderei navegar até às Índias?"),
        //     new Dialog("Você", "Não se preocupe, seu Pedro!"),
        //     new Dialog("Você", "Vou dar um jeito!")
        // };
    }

    void Update() {
        if (this.dialogs != null && this.dialogs.Length > 0 && this.IsDialogBoxActivated()) {
            if (!this.nextMessage) {
                this.ResetDialog();
            }
            if (!this.isSign) {
                this.nextMessage = false;
                if (this.currentMessageIndex >= this.dialogs.Length) {
                    this.ResetDialog();
                } else {
                    this.ShowMessage();
                }
            }
        }
    }

    private void FireButton1() {
        this.nextMessage = true;
    }

    public bool IsDialogBoxActivated() {
        return this.dialogBox != null && this.dialogBox.activeInHierarchy;
    }

    private void ShowMessage() {
        GameManager.Instance.Player.CanMove = false;

        string speaker = this.dialogs[this.currentMessageIndex].Speaker;
        string sentence = this.dialogs[this.currentMessageIndex].Sentence;

        if (speaker == null) {
            this.titleBox.SetActive(false);
        } else {
            this.titleBox.SetActive(true);
        }
        this.title.text = speaker;
        this.message.text = sentence;
        
        this.currentMessageIndex++;
    }

    private void ResetDialog() {
        this.nextMessage = false;
        this.dialogs = null;
        this.currentMessageIndex = 0;
        this.message.text = "";
        this.title.text = "";
        this.dialogBox.SetActive(false);
        this.titleBox.SetActive(false);
        UIManager.Instance.IsDialogActive = false;
        GameManager.Instance.Player.CanMove = true;
    }

    public void ShowDialog(Dialog[] dialogs) {
        if (dialogs.Length > 0) {
            this.dialogs = dialogs;
            this.dialogBox.SetActive(true);
            if (this.dialogs[0].Speaker != null) {
                this.titleBox.SetActive(true);
            }
            this.nextMessage = true;
            UIManager.Instance.IsDialogActive = true;
        }
    }

    public void ShowSign(string sign) {
        this.isSign = true;
        this.dialogBox.SetActive(true);
        this.message.text = sign;
        UIManager.Instance.IsDialogActive = true;
    }
}