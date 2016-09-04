using UnityEngine;
using UnityEngine.SceneManagement;
using Spine.Unity;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public Collider2D groundDetector;
    public float jumpForce = 1.0f;
    public float walkSpeed = 10.0f;
    public float fireDelay = 0.5f;

    private ShootingController shootingController;
    private int groundLayer;
    private Rigidbody2D rb;
    private bool goingRight;
    private float nextFireTime;
    private SkeletonAnimation skeletonAnimation;

    void Awake()
    {
        this.groundLayer = LayerMask.GetMask("Ground");
        this.rb = GetComponent<Rigidbody2D>();
        this.shootingController = this.GetComponent<ShootingController>();
        this.skeletonAnimation = this.GetComponentInChildren<SkeletonAnimation>();
        goingRight = true;
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0 && CanJump())
        {
            Jump();
        }

        Walk(Input.GetAxis("Horizontal"));
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var now = Time.realtimeSinceStartup;

        if (Input.GetAxisRaw("Fire1") > 0 && now >= nextFireTime)
        {
            nextFireTime = now + fireDelay;
            Vector2 shootDirection;
            if (horizontal == 0 && vertical == 0)
            {
                shootDirection = goingRight ? Vector2.right : Vector2.left;
            }
            else {
                shootDirection = new Vector2(horizontal, vertical);
            }
            this.shootingController.Fire(shootDirection);
        }
    }

    bool CanJump()
    {
        return groundDetector.IsTouchingLayers(groundLayer);
    }

    void Jump()
    {
        var velocity = this.rb.velocity;
        velocity.y = jumpForce;
        this.rb.velocity = velocity;
    }

    void OnFellOff()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Walk(float direction)
    {
        if (direction == 0)
        {
            this.skeletonAnimation.AnimationName = "idle";
        } else {
            var velocity = this.rb.velocity;
            velocity.x = walkSpeed * direction;
            this.rb.velocity = velocity;
            this.skeletonAnimation.AnimationName = "run";
        }

        var currentScale = this.transform.localScale;
        if (direction > 0 && !goingRight)
        {
            goingRight = true;
            currentScale.x = 1;
        }
        else if (direction < 0 && goingRight)
        {
            currentScale.x = -1;
            goingRight = false;
        }

        this.transform.localScale = currentScale;
    }
}
