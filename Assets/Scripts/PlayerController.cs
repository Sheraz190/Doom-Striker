using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity;

public class PlayerController : MonoBehaviour
{


    #region Variables

    public GameObject player;
    public static PlayerController Instance;
    public Rigidbody2D rb;
    public FixedJoystick joyStick;
    bool isGrounded = true;
   [Space, Header("Float Variables")]
    public float jumpForce = 1;
    public float moveSpeed = 3;
    public float Health = 10;
    private Vector2 originalScale;
    public GunsTypes currentGun;
    #endregion

    private void Start()
    {
        
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
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
           // Debug.Log(" velocity" + rb.velocity.y);
        }
        else if (rb.velocity.y < 6)
        {
            rb.gravityScale = 6;
        }
    }

    private void Movings()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
#else
        rb.velocity = new Vector2(joyStick.Horizontal * moveSpeed, rb.velocity.y);
#endif
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
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector2(-originalScale.x, originalScale.y);

        }
        else if (horizontalInput > 0)
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
        }

        #endif
    }


    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(Health>0)
            {
                Health -= 2;
                GamePlayPanel.Instance.DisplayHealth();
            }
            if (Health <= 0)
            {
                Debug.Log("Health Ends");
            }
        }
    }

   
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

        





}










