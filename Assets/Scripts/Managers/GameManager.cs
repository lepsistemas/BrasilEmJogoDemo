﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    public static GameManager Instance {
        get {
            return instance;
        }
    }

    [SerializeField]
    private Player player = null;

    public Player Player {
        get {
            return this.player;
        }
    }

    void Awake() {
        instance = this;

        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;

        // TODO
        // Move to a QuestManager for each Quest will have its own day duration maybe???
        TimeManager.Instance.DayDurationInSeconds = 0.2f;
        TimeManager.Instance.InitialDate = DateTime.ParseExact("1500-01-01", "yyyy-MM-dd", new System.Globalization.CultureInfo("pt-BR"), System.Globalization.DateTimeStyles.None);
        TimeManager.Instance.CurrentDate = TimeManager.Instance.InitialDate;
        TimeManager.Instance.EndDate = DateTime.ParseExact("1500-03-08", "yyyy-MM-dd", new System.Globalization.CultureInfo("pt-BR"), System.Globalization.DateTimeStyles.None);
    }

    void Update() {
        if (ControllerManager.Instance.CancelButtonFired) {
            MenuManager.Instance.OpenCloseMenu();
        }
    }

    void OnEnable() {
        TimeManager.Instance.OnTimeAdvance += this.OnTimeAdvance;
        AudioManager.Instance.PlayMusic(AudioManager.START_MENU_MUSIC_INDEX);
    }

    void OnDisable() {
        TimeManager.Instance.OnTimeAdvance -= this.OnTimeAdvance;
        AudioManager.Instance.PauseMusic(AudioManager.START_MENU_MUSIC_INDEX);
    }

    private void OnTimeAdvance() {
        if (TimeManager.Instance.CurrentDate.CompareTo(TimeManager.Instance.EndDate) >= 0) {
            OnGameOver?.Invoke();
        }
    }

    public delegate void OnGameOverHandler();

    public event OnGameOverHandler OnGameOver;
}
