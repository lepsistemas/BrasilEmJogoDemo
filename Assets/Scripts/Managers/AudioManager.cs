using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager instance;

    public static AudioManager Instance {
        get {
            return instance;
        }
    }

    public static int START_MENU_MUSIC_INDEX = 0;

    public AudioSource[] music;
    
    void Awake() {
        if (instance != null && instance != this && this.gameObject != null) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    public void PlayMusic(int index) {
        this.music[index].Play();
    }

    public void PauseMusic(int index) {
        this.music[index].Pause();
    }
}
