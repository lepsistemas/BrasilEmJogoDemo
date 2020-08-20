using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour {

    private static TimeManager instance;

    public static TimeManager Instance {
        get {
            return instance;
        }
    }

    private void Awake() {
        if (instance != null && instance != this && this.gameObject != null) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    private float dayDurationInSeconds;

    public float DayDurationInSeconds {
        get {
            return this.dayDurationInSeconds;
        }
        set {
            this.dayDurationInSeconds = value;
        }
    }

    private DateTime initialDate;

    public DateTime InitialDate {
        get {
            return this.initialDate;
        }
        set {
            this.initialDate = value;
        }
    }
    
    private DateTime endDate;

    public DateTime EndDate {
        get {
            return this.endDate;
        }
        set {
            this.endDate = value;
        }
    }

    private DateTime currentDate;

    public DateTime CurrentDate {
        get {
            return this.currentDate;
        }
        set {
            this.currentDate = value;
        }
    }

    private bool pause = false;

    void Start() {
        InvokeRepeating("AdvanceTime", 1f, this.dayDurationInSeconds);
    }

    void Update() {
    }

    void AdvanceTime() {
        if (this.initialDate != null && this.endDate != null && !this.pause) {
            this.MakeItTomorrow();
            OnTimeAdvance?.Invoke();
        }
    }

    public void Pause() {
        this.pause = true;
    }

    public void Resume() {
        this.pause = false;
    }

    public void MakeItTomorrow() {
        DateTime newCurrentDate = this.currentDate.AddDays(1);
        if (newCurrentDate.CompareTo(this.endDate) > 0) {
            newCurrentDate = this.endDate;
        }
        if (newCurrentDate.CompareTo(this.initialDate) < 0) {
            newCurrentDate = this.initialDate;
        }

        this.currentDate = newCurrentDate;
    }

    public delegate void OnTimeAdvanceHandler();

    public event OnTimeAdvanceHandler OnTimeAdvance;
}