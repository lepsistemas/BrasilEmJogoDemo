using UnityEngine;
using UnityEngine.EventSystems;

public class GameMenu : MonoBehaviour {

    [SerializeField]
    private GameObject defaultSelectedButton = null;

    
    void Start() {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.defaultSelectedButton);
    }

    void Update() {
        
    }

    public void Close() {
        MenuManager.Instance.OpenCloseMenu();
    }

    public void QuitGame() {
        Application.Quit();
    }
}
