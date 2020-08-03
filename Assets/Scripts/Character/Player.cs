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
            return !GameManager.Instance.GameOver && this.canMove;
        }
        set {
            this.canMove = value;
        }
    }

    protected override void Start() {
        base.Start();
        this.canMove = true;
        this.speed = Player.DEFAULT_SPEED;
    }

    protected override void Update() {
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, this.min.x, this.max.x), Mathf.Clamp(this.transform.position.y, this.min.y, this.max.y), this.transform.position.z);
        base.Update();
    }

    public void SetLimits(Vector3 min, Vector3 max) {
        this.min = min;
        this.max = max;
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
            if (ControllerManager.Instance.Button3Fired) {
                factor = 2f;
            }
            this.speed = Player.DEFAULT_SPEED * factor;
            this.animator.speed = factor;
        }
    }
}
