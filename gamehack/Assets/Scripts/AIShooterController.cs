using UnityEngine;
using System.Collections;

public class AIShooterController : ShootingController
{
    public Transform target;
    public float shootDelay = 1f;

    private float nextShot;

    void Awake()
    {
        nextShot = Time.realtimeSinceStartup;
    }

    void Update()
    {
        if (nextShot < Time.realtimeSinceStartup)
        {
            nextShot = Time.realtimeSinceStartup + shootDelay;
            Fire(target.position - this.transform.position);
        }
    }
}
