using UnityEngine;
using System.Collections;

public class ShootingController : MonoBehaviour
{
    public GameObject bullet;
    public Transform origin;

    public void Fire(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        var bulletInstance = (GameObject)Instantiate(bullet, origin.position, rotation);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = direction.normalized * 20;
    }
}
