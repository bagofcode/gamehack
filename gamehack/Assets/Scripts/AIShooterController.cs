using UnityEngine;
using System.Collections;

public enum AIShooterState
{
    TARGETTING, WAITING
}

public struct AIShooterInfo
{
    public Vector2 from;
    public Vector2? target;
    public AIShooterState state;
}

public class AIShooterController : ShootingController
{
    public Transform target;
    public float shootDelay = 1f;
    public float range = 2;

    private float nextShot;
    private float rangeSqr;

    private AIShooterInfo info;

    void Awake()
    {
        nextShot = Time.realtimeSinceStartup;
        rangeSqr = range * range;
    }

    void Update()
    {
        this.info.from = this.gameObject.transform.position;

        if (nextShot < Time.realtimeSinceStartup)
        {
            Vector2 direction = target.position - this.transform.position;
            this.info.target = direction;

            if (rangeSqr >= direction.sqrMagnitude)
            {
                nextShot = Time.realtimeSinceStartup + shootDelay;
                Fire(direction);
            }
        }
        else {
            this.info.target = null;
        }

        this.gameObject.SendMessage("OnAITargetting", this.info, SendMessageOptions.DontRequireReceiver);
    }
}
