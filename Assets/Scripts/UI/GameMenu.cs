using UnityEngine;
using UnityEngine.EventSystems;

public class GameMenu : MonoBehaviour {

    [SerializeField]
    private GameObject schoolBagButton = null;

    [SerializeField]
    private GameObject quitButton = null;

    [SerializeField]
    private GameObject cancelButton = null;

    [SerializeField]
    private GameObject confirmDialog = null;

    [SerializeField]
    private GameObject menu = null;

    void Awake() {
        this.confirmDialog.SetActive(false);
    }
    
    void Start() {
        
    }

    void Update() {
        
    }

    void OnEnable() {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.schoolBagButton);
    }

    void OnDisable() {
        this.confirmDialog.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.schoolBagButton);
    }

    public void Close() {
        MenuManager.Instance.OpenCloseMenu();
    }

    public void ConfirmQuitGame() {
        this.menu.SetActive(false);
        this.confirmDialog.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.cancelButton);
    }

    public void CloseConfirm() {
        this.confirmDialog.SetActive(false);
        this.menu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.quitButton);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
