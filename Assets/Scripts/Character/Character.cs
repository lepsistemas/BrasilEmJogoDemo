using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour {

    protected const float DEFAULT_SPEED = 5f;

    protected Vector2 direction;
    protected float speed;

    protected Animator animator;
    
    private Rigidbody2D body;

    protected virtual void Start() {
        this.body = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    protected virtual void Update() {
        this.SetSpeed();
        this.SetDirection();
        this.Move();
        this.Animate();
    }

    public void Move() {
        this.body.velocity = this.direction.normalized * this.speed;
    }

    public bool IsMoving() {
        return this.direction.x != 0 && this.direction.y != 0;
    }

    protected void Animate() {
        if (this.animator != null) {
            this.animator.SetFloat("moveX", this.direction.x);
            this.animator.SetFloat("moveY", this.direction.y);

            if (this.direction.x == 1 || this.direction.x == -1 
                || this.direction.y == 1 || this.direction.y == -1) {
                this.animator.SetFloat("lastMoveX", this.direction.x);
                this.animator.SetFloat("lastMoveY", this.direction.y);
            }
        }
    }

    protected virtual void SetDirection() {
    }

    protected virtual void SetSpeed() {
    }
}
