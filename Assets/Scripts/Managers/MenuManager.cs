using UnityEngine;

public class MenuManager : MonoBehaviour {

    private static MenuManager instance;

    public static MenuManager Instance {
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

    public void OpenCloseMenu() {
        UIManager.Instance.Menu.gameObject.SetActive(!UIManager.Instance.Menu.gameObject.activeInHierarchy);
        if (UIManager.Instance.Menu.gameObject.activeInHierarchy) {
            TimeManager.Instance.Pause();
        } else {
            TimeManager.Instance.Resume();
        }
    }
}
