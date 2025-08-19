using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    #region Game Objects/ Variables
    public Rigidbody2D rb;
    public GameObject player;
    private Animator animator;
    private Vector2 originalScale;
    public FixedJoystick joyStick;
    private Vector3 currentPosofPlayer;
    [Space, Header("Variables")]
    public float Health = 10;
    public float jumpForce = 1;
    public float moveSpeed = 3;
    private bool isJumping = false;
    private bool isGrounded = true;
    public bool canMove=true;
    private bool canDoublejump = true;
    private int jumpCount = 0;
    private float joystickInput;
    private bool notCollided=true;
    #endregion

    private void Start()
    {   
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        animator = GetComponent<Animator>();
        CheckPlayerPosition();
        canMove = true;
    }

    private void OnEnable()
    {
        StartCoroutine(ResetPostion());
        Health = 10;
    
    }


    private IEnumerator ResetPostion()
    {
        yield return null;
        {
            ResetPlayerPosition();
        }
    }
    private void Update()
    {
        DetectInput();
        JumpForEditor();
        SetGravity();
        ChangeDirectionForEditor();
        Movings();
    }

    private void SetGravity()
    {
        if (rb.velocity.y > 0 || rb.velocity.y == 0)
        {
            rb.gravityScale = 2;
        }
        else if (rb.velocity.y < 6)
        {
            rb.gravityScale = 6;
        }
    }

    private void Movings()
    {
//#if UNITY_EDITOR
//        if (Input.GetKey(KeyCode.D))
//        {
//            isWalking = true;
//            animator.SetBool("isWalk", true);
//            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
//        }
//        else if (Input.GetKey(KeyCode.A))
//        {
//            isWalking = true;
//            animator.SetBool("isWalk", true);
//            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
//        }
//        else
//        {
//            isWalking = false;
//        }
       
//#else
        if(canMove)
        {
            joystickInput = joyStick.Horizontal;
        }
        else
        {
            joystickInput = 0;
         
            
        }
         rb.velocity = new Vector2(joystickInput * moveSpeed, rb.velocity.y);
        
        
        
       
        
//#endif
    }
    
    public void StopMoving()
    {
        canMove = false;
        joyStick.OnPointerUp(null);
        joystickInput = 0;
    }

    public void SetWalkFalse()
    {
        animator.SetBool("isWalk", false);
    }

    public void SetWalkTrue()
    {
        animator.SetBool("isWalk", true);
    }

    private void ChangeDirectionForEditor()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector2(originalScale.x, originalScale.y);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector2(-originalScale.x, originalScale.y);
        }
    }

    

    private void DetectInput()
    {
        float horizontalInput = joyStick.Horizontal;
        if (horizontalInput < 0&&canMove)
        {
            transform.localScale = new Vector2(-originalScale.x, originalScale.y);

        }
        else if (horizontalInput > 0&&canMove)
        {
            transform.localScale = new Vector2(originalScale.x, originalScale.y);
        }
    }

    private void JumpForEditor()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            isJumping = true;
         }
        else
        {
            isJumping = false;
        }
        AddJumpAnim();
        #endif
    }

    private void AddJumpAnim()
    {
        if(isJumping)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }

    public void Jump()
    {
        if (isGrounded|| canDoublejump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            jumpForce = 250;
            CheckIfDoubleJump();
        }
    }

    private void CheckIfDoubleJump()
    {
        if(jumpCount>=2)
        {
            canDoublejump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpForce = 500;
            if (jumpCount>=2)
            {
                jumpCount = 0;
                canDoublejump = true;
            }
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (notCollided)
            {
                if (Health > 0 )
                {
                    Health -= 2;
                    GamePlayPanel.Instance.DisplayHealth();
                }
                else if (Health <= 0)
                {
                    GameManager.Instance.GameEndMethod();
                }
                notCollided=false;
            }
            
        }
    }
    
 
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            notCollided = true; 
        }
    }

    private void ResetPlayerPosition()
    {
        player.transform.localPosition = currentPosofPlayer;
    }

    private void CheckPlayerPosition()
    {
        currentPosofPlayer = player.transform.localPosition;
    }



    //public void ResetToIdle()
    //{
    //    canMove = false;
    //    // Stop movement completely
    //    rb.velocity = Vector2.zero;
    //    rb.angularVelocity = 0f;

    //    // Reset animator states
    //    animator.SetBool("isWalk", false);
    //    animator.SetBool("jump", false);

    //    // Reset joystick input
    //    LockJoystick();

     
    //}


    public void  ResetPlayerHealth()
    {
        Health = 10;
    }



    //public void LockJoystick()
    //{
    //    canMove = false; // Ignore input in Movings()

    //    // Stop any current movement
    //    rb.velocity = Vector2.zero;
    //    rb.angularVelocity = 0f;

    //    // Force idle animations
    //    animator.SetBool("isWalk", false);
    //    animator.SetBool("jump", false);

    //    // Option 1: Disable joystick completely (best for touch devices)
    //    if (joyStick != null)
    //    {
    //        joyStick.gameObject.SetActive(false);
    //    }
    //}

}










