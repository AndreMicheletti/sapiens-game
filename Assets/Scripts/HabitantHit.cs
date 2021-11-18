using UnityEngine;

public class HabitantHit : MonoBehaviour
{
    public Habitant habitant;

    private BoxCollider2D boxCollider;

    private void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    public void ActivateHitBox () {
        boxCollider.enabled = true;
    }
    public void DectivateHitBox () {
        boxCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(habitant.GetTargetTag())) {
            Habitant otherHabitant = other.GetComponent<Habitant>();
            otherHabitant.Hit(habitant);
            DectivateHitBox();
        }
    }
}
