using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    [SerializeField]
    private GameObject newGameButton = null;

    void Start() {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.newGameButton);
    }

    public void NewGame() {
        SceneManager.LoadScene("LoadLisbon");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
