using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    private float initialZ = -10;
    private Vector3 velocity = Vector3.zero;
    private void Awake() {
        initialZ = transform.position.z;
    }

    private void LateUpdate()
    {
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothSpeed);
        transform.position = new Vector3(smoothPos.x, smoothPos.y, initialZ);
    }
}
