using System;
using UnityEngine;

public class Obstacle : MonoBehaviour, IComparable<Obstacle> {

    public SpriteRenderer ObstacleRenderer {
        get;
        set;
    }

    private Color defaultColor;

    private Color fadedColor;

    void Start() {
        this.ObstacleRenderer = this.GetComponent<SpriteRenderer>();
        
        this.defaultColor = this.ObstacleRenderer.color;
        this.fadedColor = this.defaultColor;
        this.fadedColor.a = 0.7f;
    }

    void Update() {
        
    }

    public int CompareTo(Obstacle other) {
        if (ObstacleRenderer.sortingOrder > other.ObstacleRenderer.sortingOrder) {
            return 1;
        } else if (ObstacleRenderer.sortingOrder < other.ObstacleRenderer.sortingOrder) {
            return -1;
        }
        return 0;
    }

    public void FadeIn() {
        this.ObstacleRenderer.color = this.defaultColor;
    }

    public void FadeOut() {
        this.ObstacleRenderer.color = this.fadedColor;
    }
}