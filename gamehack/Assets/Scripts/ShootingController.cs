using UnityEngine;
using Assets.Scripts.Util;

public class ShootingController : MonoBehaviour
{
    public GameObject bullet;
    public Transform origin;
    public GameObject ignore;

    public void Fire(Vector2 direction)
    {
        var rotation = QuaternionUtil.FromDirection2D(direction);
        
        var bulletInstance = (GameObject) Instantiate(bullet, origin.position, rotation);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = direction.normalized*20;
        bulletInstance.GetComponent<BulletController>().ignore = ignore;
    }
}