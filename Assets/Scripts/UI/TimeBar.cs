﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour {

    private Image bar;

    [SerializeField]
    private Text minDateText = null;
    
    [SerializeField]
    private Text maxDateText = null;

    private float currentPercentage;
    
    // private Quest quest;

    void Start() {
        this.bar = GetComponent<Image>();
        this.bar.fillAmount = 0f;
        this.currentPercentage = 0f;

        if (TimeManager.Instance.InitialDate != null && TimeManager.Instance.EndDate != null) {
            this.minDateText.text = TimeManager.Instance.InitialDate.ToString("dd/MM/yyyy");
            this.maxDateText.text = TimeManager.Instance.EndDate.ToString("dd/MM/yyyy");
        }
    }

    void Update() {
        this.UpdateCurrentPercentage();
        this.bar.fillAmount = Mathf.Lerp(this.bar.fillAmount, this.currentPercentage, Time.deltaTime * (1 / TimeManager.Instance.DayDurationInSeconds));
    }

    public void UpdateCurrentPercentage() {
        float minPercentage = 0f;
        float maxPercentage = 1f;
        
        float minDateBinary = (float) TimeManager.Instance.InitialDate.ToBinary();
        float maxDateBinary = (float) TimeManager.Instance.EndDate.ToBinary();

        float currentDateBinary = (float) TimeManager.Instance.CurrentDate.ToBinary();
        
        this.currentPercentage = RangePercentage.Calculate(
            minPercentage, maxPercentage, 
            minDateBinary, maxDateBinary, 
            currentDateBinary);
    }
}
