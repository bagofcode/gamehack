using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Rigidbody2D target;
    public float followSpeed = 2.0f;
    public Vector2 distanceInFront;

    void FixedUpdate()
    {
        Vector2 desiredPosition = new Vector2(target.velocity.x * distanceInFront.x, target.velocity.y * distanceInFront.y) + target.position;

        Vector2 targetPosition = Vector2.Lerp(this.transform.position, desiredPosition, Time.deltaTime * followSpeed);

        this.transform.position = new Vector3(targetPosition.x, targetPosition.y, this.transform.position.z);
    }
}
