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

    void Start() {
        this.currentPercentage = 0f;
        this.avatar.color = new Color(255, 255, 255, 1f);
        this.currentPhaseText.text = "A caminho das Índias";
    }

    void Update() {
        this.UpdateCurrentPercentage();
        this.avatar.color = new Color(255, 255, 255, Mathf.Lerp(this.avatar.color.a, this.currentPercentage, Time.deltaTime * (1 / TimeManager.Instance.DayDurationInSeconds)));
        this.currentDateText.text = TimeManager.Instance.CurrentDate.ToString("dd/MM/yyyy");
    }

    internal void UpdateCurrentPercentage() {
        float minPercentage = 1f;
        float maxPercentage = 0f;
        
        float minDateBinary = (float) TimeManager.Instance.InitialDate.ToBinary();
        float maxDateBinary = (float) TimeManager.Instance.EndDate.ToBinary();
        float currentDateBinary = (float) TimeManager.Instance.CurrentDate.ToBinary();

        // float percent = (newCurrentBinary - minDateBinary) / (maxDateBinary - minDateBinary);
        // this.currentPercentage = percent * (maxPercentage - minPercentage) + minPercentage;
        this.currentPercentage = RangePercentage.Calculate(
            minPercentage, maxPercentage, 
            minDateBinary, maxDateBinary, 
            currentDateBinary);
    }
}
