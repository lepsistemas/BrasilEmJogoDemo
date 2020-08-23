using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    new private const float DEFAULT_SPEED = Character.DEFAULT_SPEED - 2f;

    private Vector3 min;
    private Vector3 max;

    private bool canMove;

    public bool CanMove {
        get {
            return this.canMove
                    && !UIManager.Instance.DialogBox.gameObject.activeInHierarchy
                    && !UIManager.Instance.Menu.gameObject.activeInHierarchy;
        }
        set {
            this.canMove = value;
        }
    }

    private bool shouldDisappear;

    private float transparency;

    protected override void Start() {
        base.Start();
        this.canMove = true;
        this.shouldDisappear = false;
        this.transparency = 1f;
        this.speed = Player.DEFAULT_SPEED;
        GameManager.Instance.OnGameOver += this.OnGameOver;
    }

    private void OnGameOver() {
        this.canMove = false;
        this.shouldDisappear = true;
    }

    protected override void Update() {
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, this.min.x, this.max.x), Mathf.Clamp(this.transform.position.y, this.min.y, this.max.y), this.transform.position.z);
        base.Update();
        if (this.shouldDisappear) {
            this.Disappear();
        }
    }

    public void SetLimits(Vector3 min, Vector3 max) {
        this.min = new Vector3(min.x + 0.5f, min.y + 0.5f, min.z);
        this.max = new Vector3(max.x - 0.5f, max.y - 0.5f, max.z);;
    }

    protected override void SetDirection() {
        this.direction = Vector2.zero;
        if (this.CanMove) {
            this.direction = new Vector2(ControllerManager.Instance.X, ControllerManager.Instance.Y);
        }
    }

    protected override void SetSpeed() {
        float factor = 1f;
        if (this.CanMove) {
            if (ControllerManager.Instance.SecondaryButtonFired) {
                factor = 2f;
            }
            this.speed = Player.DEFAULT_SPEED * factor;
            this.animator.speed = factor;
        }
    }

    private void Disappear() {
        float factor = 0.01f;
        Color color = this.gameObject.GetComponent<SpriteRenderer>().color;
        if (color.a > 0f) {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, Mathf.Lerp(color.a, this.transparency, Time.deltaTime));
            this.transparency -= factor;
        }
        if (color.a <= factor) {
            this.gameObject.SetActive(false);
        }
    }
}
