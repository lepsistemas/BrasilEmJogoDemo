using System;
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

    private bool gameOver;

    public bool GameOver {
        get {
            return this.gameOver;
        }
    }

    void Awake() {
        instance = this;
        this.gameOver = false;

        // TODO
        // Move to a QuestManager for each Quest will have its own day duration maybe???
        TimeManager.Instance.DayDurationInSeconds = 0.5f;
        TimeManager.Instance.InitialDate = DateTime.ParseExact("1500-01-01", "yyyy-MM-dd", new System.Globalization.CultureInfo("pt-BR"), System.Globalization.DateTimeStyles.None);
        TimeManager.Instance.EndDate = DateTime.ParseExact("1500-03-08", "yyyy-MM-dd", new System.Globalization.CultureInfo("pt-BR"), System.Globalization.DateTimeStyles.None);
    }

    void Start() {
        
    }

    void Update() {
        if (ControllerManager.Instance.CancelButtonFired) {
            MenuManager.Instance.OpenCloseMenu();
        }
    }

    void OnEnable() {
        TimeManager.Instance.OnTimeAdvance += this.Advance;
    }

    void OnDisable() {
        TimeManager.Instance.OnTimeAdvance -= this.Advance;
    }

    private void Advance() {
        TimeManager.Instance.MakeItTomorrow();
        
        if (TimeManager.Instance.CurrentDate.CompareTo(TimeManager.Instance.EndDate) >= 0) {
            TimeManager.Instance.Pause();
            this.gameOver = true;
            Debug.Log("Call Game Over System!");
        }
    }
}
