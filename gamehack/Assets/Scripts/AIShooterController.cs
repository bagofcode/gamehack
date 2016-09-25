using UnityEngine;
using System.Collections;

public enum AIShooterState
{
    TARGETTING,
    WAITING,
    NOT_IN_RANGE,
    SHOOTING
}

public struct AIShooterInfo
{
    public Vector2 From;
    public Vector2 Target;
    public float ShootDelay;
    public float TimeToShoot;
    public AIShooterState State;
}

public class AIShooterController : ShootingController
{
    public Transform target;
    public float shootDelay = 2f;
    public float noFollowTime = 0.5f;
    public float range = 2;

    private float nextShot;
    private float rangeSqr;

    private AIShooterInfo info;

    void Awake()
    {
        nextShot = Time.realtimeSinceStartup + shootDelay;
        rangeSqr = range*range;
        this.info.ShootDelay = shootDelay;
        this.info.State = AIShooterState.NOT_IN_RANGE;
    }

    void Update()
    {
        this.info.From = this.gameObject.transform.position;
        this.info.TimeToShoot = nextShot - Time.realtimeSinceStartup;

        if (this.info.TimeToShoot > noFollowTime)
        {
            this.info.Target = target.position - this.transform.position;
        }

        if (rangeSqr >= this.info.Target.sqrMagnitude)
        {
            if (this.info.TimeToShoot <= 0)
            {
                nextShot = Time.realtimeSinceStartup + shootDelay;
                this.info.TimeToShoot = 0;
                Fire(this.info.Target);
                this.info.State = AIShooterState.SHOOTING;
            }
            else
            {
                this.info.State = AIShooterState.WAITING;
            }
        }
        else
        {
            this.info.State = AIShooterState.NOT_IN_RANGE;
            nextShot = Time.realtimeSinceStartup + shootDelay;
        }

        this.gameObject.SendMessage("OnAITargetting", this.info, SendMessageOptions.DontRequireReceiver);
    }
}