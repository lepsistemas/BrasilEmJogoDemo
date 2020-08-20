using System;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    [SerializeField]
    private TimeBar timeBar = null;

    [SerializeField]
    private Image avatar = null;

    [SerializeField]
    private Text currentDateText = null;

    [SerializeField]
    private Text currentPhaseText = null;

    private float existencePercentage;

    private float currentPercentage;

    public TimeBar TimeBar {
        get {
            return this.timeBar;
        }
    }

    void Awake() {
        this.currentPercentage = 1f;
        this.avatar.color = new Color(255, 255, 255, 1f);
        this.currentPhaseText.text = "A Caminho das Índias";
        this.currentDateText.text = TimeManager.Instance.CurrentDate.ToString("dd/MM/yyyy");
    }

    void Update() {
        this.avatar.color = new Color(255, 255, 255, Mathf.Lerp(this.avatar.color.a, this.currentPercentage, Time.deltaTime));
    }

    void OnEnable() {
        TimeManager.Instance.OnTimeAdvance += this.OneMoreDay;
    }

    void OnDisable() {
        TimeManager.Instance.OnTimeAdvance -= this.OneMoreDay;
    }

    void OneMoreDay() {
        this.UpdateCurrentPercentage();
        this.currentDateText.text = TimeManager.Instance.CurrentDate.ToString("dd/MM/yyyy");
    }

    internal void UpdateCurrentPercentage() {
        float minPercentage = 1f;
        float maxPercentage = 0f;
        
        float minDateBinary = (float) TimeManager.Instance.InitialDate.ToBinary();
        float maxDateBinary = (float) TimeManager.Instance.EndDate.ToBinary();
        float currentDateBinary = (float) TimeManager.Instance.CurrentDate.ToBinary();

        this.currentPercentage = RangePercentage.Calculate(
            minPercentage, maxPercentage, 
            minDateBinary, maxDateBinary, 
            currentDateBinary);
    }
}
