using System.Collections.Generic;
using UnityEngine;

public class Habitant : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sprite;
    public Transform hold;
    public float speed = 1f;

    protected Rigidbody2D body;
    protected BoxCollider2D boxCollider;

    protected Vector2 moveVec = new Vector2();

    protected float direction = -1f;

    void Awake() {
        body = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    protected void Update() {
        bool moving = moveVec.magnitude > 0;
        bool attacking = IsAttacking();

        // Apply movement
        if (moving && !attacking) {
            direction = moveVec.x;
            body.AddForce(moveVec * speed);
        };

        transform.localScale = new Vector3(direction > 0 ? -1 : 1, 1, 1);
        // sprite.flipX = direction > 0;
        animator.SetBool("moving", moving);
        UpdateHabitant();
    }

    protected bool IsAttacking () {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("attack");
    }

    protected void Attack() {
        if (IsAttacking()) return;
        animator.Play("attack", 0);
    }
    public void Hit (Habitant from) {
        Vector2 dist = transform.position - from.transform.position;
        body.AddForce(dist * 1000f);
    }

    public virtual void UpdateHabitant() {}

    public virtual string GetTargetTag() {
        return "Habitant";
    }
}
