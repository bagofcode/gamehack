using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public float lifetime = 3.0f;

    private float groundLayer;
    private float expirationTime;

    void Awake()
    {
        groundLayer = LayerMask.NameToLayer("Ground");
        expirationTime = Time.realtimeSinceStartup + lifetime;
    }

    void Update()
    {
        if (Time.realtimeSinceStartup >= expirationTime)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        bool hitSomething = false;
        if (other.gameObject.layer == groundLayer)
        {
            hitSomething = true;
        }

        var healthController = other.gameObject.GetComponent<HealthController>();
        if (healthController != null)
        {
            healthController.TakeDamage(1.0f);
            hitSomething = true;
        }

        if (hitSomething)
        {
            Destroy(this.gameObject);
        }
    }
}
