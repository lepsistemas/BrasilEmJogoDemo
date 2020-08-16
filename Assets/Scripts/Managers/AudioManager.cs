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
    
    void Start() {
        instance = this;
    }

    public void PlayMusic(int index) {
        this.music[index].Play();
    }
}
