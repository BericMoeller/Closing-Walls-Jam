using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 12f;
    private float jumpingPower = 4f;
    private bool isFacingRight = true;
    private int jumptimer = 0;
    private bool canJump = true;
    private bool canWallJump = false;
    private bool disableInput = false;
    private bool boosting = false;
    private bool upboost = false;
    private int boostTimer = 0;
    private int upboostTimer = 0;
    private int boostDuration = 10;
    private int upboostDuration = 5;

    Animator animator;// animation stuff disregard

    [SerializeField] 
    private Rigidbody2D rb;
    
    [SerializeField] 
    private Transform groundCheck;

    [SerializeField]
    private Transform backCheck;

    [SerializeField]
    private Transform frontCheck;

    [SerializeField] 
    private LayerMask groundLayer;

    [SerializeField]
    private Transform chestCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        checkForCrush();
        if (!disableInput)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            // reg jump

            if (Input.GetKey(KeyCode.W) && isGrounded() && canJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                jumptimer = 10;
                canJump = false;
                canWallJump = true;
            }

            // wall jump

            if (Input.GetKey(KeyCode.W) && canJump && canWallJump && isHittingWall() != 0 && !isGrounded())
            {
                rb.velocity = new Vector2(jumpingPower * isHittingWall() * speed, jumpingPower);
                jumptimer = 10;
                canJump = false;
                canWallJump = false;
            }


            // fall handling

            if ((Input.GetKey(KeyCode.W) && rb.velocity.y > 0f) && jumptimer > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + (jumpingPower * jumptimer / 10f));
                jumptimer--;
            }

            if (!Input.GetKey(KeyCode.W))
            {
                if (rb.velocity.y > 0f) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.9f);
                canWallJump = !isGrounded(); // trust me it just works dont even ask the reasoning behind this

                jumptimer = 0;
                canJump = true;
            }

        }
        // Animation 'Logic'
        if (canJump && rb.velocity.Equals(Vector2.zero))
        {
            Idle();
        }
        else if (canJump) 
        {
            Run();
        }
        else
        {
            Jump();
        }


        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed * (boosting ? 3f : 1f),  (upboost ? 50f : rb.velocity.y)); // this is so fucked
        
        if (boosting)
        {
            boostTimer--;
            Debug.Log("sideboost: " + boostTimer);
            if (boostTimer == 0) boosting = false;
        }

        if (upboost)
        {
            upboostTimer--;
            Debug.Log("upboost: " + upboostTimer);
            if (upboostTimer == 0) upboost = false;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .2f, groundLayer);
    }

    private int isHittingWall()
    {
        // 1 - hitting wall on front
        // 0 - not hitting wall
        //-1 - hitting wall on back

        // ^ used to multiply x direction to boost off side of wall

        if (Physics2D.OverlapCircle(backCheck.position, .2f, groundLayer))
        {
            if (isFacingRight)
            {
                Debug.Log("Left");
                return 1;
            }
            else
            {
                Debug.Log("Right");
                return -1;
            }      
        }

        if (Physics2D.OverlapCircle(frontCheck.position, .2f, groundLayer))
        {
            if (!isFacingRight)
            {
                Debug.Log("Left");
                return 1;
            }
            else
            {
                Debug.Log("Right");
                return -1;
            }
        }

        return 0;
    }

    private void checkForCrush()
    {
        if(Physics2D.OverlapCircle(chestCheck.position, 0.1f, groundLayer))
        {
            LevelController.Reset();
        }
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void levelEnd()
    {
        disableInput = true;
        rb.velocity = Vector3.zero;
    }
    public void Boost(float power)
    {
        // rb.velocity = new Vector2(rb.velocity.x, power + rb.velocity.y);
        upboost = true;
        upboostTimer = upboostDuration;
        jumptimer = 0;
    }
    public void BoostSide()
    {
        /*
        float boost = power;
        power *= goingLeft ? -1f : 1f;

        rb.velocity = new Vector2(rb.velocity.x + power, rb.velocity.y);
        */

        boosting = true;
        boostTimer = boostDuration;
    }
    public void Run()
    {
        animator.SetInteger("AnimState", 1);
    }
    public void Idle()
    {
        animator.SetInteger("AnimState", 0);
    }
    public void Jump()
    {
        animator.SetInteger("AnimState", 2);
    }
}
