using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {
    
    void Start() {
        Invoke("LaunchStartMenu", 3.0f);
    }

    void LaunchStartMenu() {
        SceneManager.LoadScene("StartMenu");
    }
}
