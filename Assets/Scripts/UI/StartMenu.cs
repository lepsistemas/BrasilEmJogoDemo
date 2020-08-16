﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    [SerializeField]
    private GameObject newGameButton = null;

    void Start() {
        AudioManager.Instance.PlayMusic(AudioManager.START_MENU_MUSIC_INDEX);
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
