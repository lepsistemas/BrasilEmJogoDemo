using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {

    [SerializeField]
    private GameObject messageBox = null;

    public GameObject MessageBox {
        get {
            return this.messageBox;
        }
    }

    [SerializeField]
    private Text message = null;

    public Text Message {
        get {
            return this.message;
        }
    }

    [SerializeField]
    private GameObject titleBox = null;

    public GameObject TitleBox {
        get {
            return this.titleBox;
        }
    }

    [SerializeField]
    private Text title = null;

    public Text Title {
        get {
            return this.title;
        }
    }
    
}
