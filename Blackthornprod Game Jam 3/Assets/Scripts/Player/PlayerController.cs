using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Animator anim;

    [Header("Jump Variables")]
    public float baseJumpForce;
    public float maxJumpForce;
    public float jumpForceMultiplier;
    float currentJumpForce;
    float jumpForceJump;

    [Header("Coyote Jump Variables")]
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float baseCoyoteJumpFloat;
    float currentCoyoteJump;
    bool isGrounded;
    bool jumped;

    [Header("Hold Jump Variables")]
    public float baseJumpTimeCounter;
    public float maxJumpTimeCounter;
    public float jumpTimeCounterMultiplier;
    float currentValueOfJumpTimeCounter;
    float currentJumpTimeCounter;
    bool isJumping;
    bool setAnim;

    [Header("Speed Variables")]
    public float baseSpeed;
    public float maxSpeed;
    public float speedMultiplier;
    float currentSpeed;

    float moveInput;

    [Header("Gravity Variables")]
    public float gravityEndOfJump;
    public float gravitySKey;

    public bool canMove = false;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentJumpForce = baseJumpForce;
        currentSpeed = baseSpeed;
        currentValueOfJumpTimeCounter = baseJumpTimeCounter;
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if(canMove)
        {
            rb2d.velocity = new Vector2(moveInput * currentSpeed, rb2d.velocity.y);
            if(moveInput == 1)
            {
                anim.SetBool("isWalking", true);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if(moveInput == -1)
            {
                anim.SetBool("isWalking", true);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == true)
        {
            ChangeValues();
            JumpStuff();
            if(Input.GetKey(KeyCode.S))
            {
                rb2d.gravityScale = gravitySKey;
            }
        }
        else
        {
          rb2d.velocity = new Vector2(0, 0);  
        }
    }

    void ChangeValues()
    {
        // change Jump value
        if(currentJumpForce < maxJumpForce)
        {
            currentJumpForce = currentJumpForce + 1 * jumpForceMultiplier * Time.deltaTime;
        }
        else
        {
            currentJumpForce = maxJumpForce;
        }

        // change JumpTimeCounter value
        if(currentValueOfJumpTimeCounter < maxJumpTimeCounter)
        {
            currentValueOfJumpTimeCounter = currentValueOfJumpTimeCounter + 1 * jumpTimeCounterMultiplier * Time.deltaTime;
        }
        else
        {
            currentValueOfJumpTimeCounter = maxJumpTimeCounter;
        }

        // change Speed value
        if(currentSpeed < maxSpeed)
        {
            currentSpeed = currentSpeed + 1 * speedMultiplier * Time.deltaTime;
        }
        else
        {
            currentSpeed = maxSpeed;
        }
    }

    void JumpStuff()
    {
        // coyote Jump
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if(isGrounded)
        {
            currentCoyoteJump = baseCoyoteJumpFloat;
            currentJumpTimeCounter = currentValueOfJumpTimeCounter;
            anim.SetBool("isGrounded", true);
            if(!Input.GetKey(KeyCode.S))
            {
                rb2d.gravityScale = 1f;
            }
            jumped = false;
        }
        else
        {
            anim.SetBool("isGrounded", false);
        }
        currentCoyoteJump -= Time.deltaTime;

        // Jump

        if(Input.GetKeyDown(KeyCode.Space) && currentCoyoteJump >= 0 && jumped == false)
        {
            isJumping = true;
            jumped = true;
            setAnim = false;
            anim.SetTrigger("TakeOff");
            rb2d.velocity = Vector2.up * currentJumpForce;
        }

        // Hold Jump
        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(currentJumpTimeCounter > 0)
            {
                rb2d.velocity = Vector2.up * currentJumpForce;
                currentJumpTimeCounter -= Time.deltaTime;
                if(currentJumpTimeCounter < 0)
                {
                    rb2d.gravityScale = gravityEndOfJump;
                    isJumping = false;
                    if(setAnim == false)
                    {
                        setAnim = true;
                        anim.SetTrigger("LookDown");
                    }
                }
            }
            else
            {
                isJumping = false;
            }
        }

        // Stopped Holding Jump
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            if(setAnim == false)
            {
                setAnim = true;
                anim.SetTrigger("LookDown");
            }
            rb2d.gravityScale = gravityEndOfJump;
        }
    }
}
