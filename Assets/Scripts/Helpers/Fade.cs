using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {
    
    void Start() {
        Invoke("LaunchStartMenu", 3.0f);
    }

    void Update() {
        
    }

    void LaunchStartMenu() {
        SceneManager.LoadScene("StartMenu");
    }
}
