using System.Collections;
using UnityEngine;

public class HabitantAI : Habitant
{
    public Transform player;

    public float stopDistance = 1f;

    private bool avoiding = false;
    private float avoidDir = 1f;

    public override void UpdateHabitant()
    {
        MoveTowards(player);
    }

    private void MoveTowards(Transform target) {
        Vector2 direction = target.position - transform.position;
        float distanceFromTarget = Vector2.Distance(transform.position, target.position);
        Debug.DrawRay(transform.position, direction);
        if (distanceFromTarget > stopDistance) {
            if (avoiding) {
                float dot = Vector2.Dot(transform.position, direction);
                Vector2 perp = Vector2.Perpendicular(direction) * avoidDir;
                direction = perp + (direction - perp) / 3;
                Debug.DrawRay(transform.position, direction, Color.red);
            } else {
                if (boxCollider.IsTouchingLayers(LayerMask.GetMask("World"))) {
                    avoiding = true;
                    avoidDir = direction.x > 0 ? 1 : -1;
                    StartCoroutine(resetAvoiding());
                }
            }
            direction.Normalize();
            moveVec = new Vector2(direction.x, direction.y);
        }
        else moveVec = Vector2.zero;
    }

    private IEnumerator resetAvoiding () {
        yield return new WaitForSeconds(0.8f);
        if (boxCollider.IsTouchingLayers(LayerMask.GetMask("World"))) {
            avoidDir *= -1;
            StartCoroutine(resetAvoiding());
        } else {
            avoiding = false;
        }
    }
    
    public override string GetTargetTag()
    {
        return "Player";
    }
}
