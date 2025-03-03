using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{


    #region Variables

    public static PlayerController Instance;
    public Rigidbody2D rb;
    public FixedJoystick joyStick;
    bool isGrounded = true;
   [Space, Header("Float Variables")]
    public float jumpForce = 300;
    public float moveSpeed = 3;
    public float Health = 10;
    private Vector2 originalScale;
    #endregion

    private void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }
    private void Update()
    {
        rb.velocity = new Vector2(joyStick.Horizontal * moveSpeed, rb.velocity.y);
        DetectInput();
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
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            Health -= 2;
            CheckPlayerLife();
        }
    }

    private void CheckPlayerLife()
    {
        if(Health<=0)
        {
            GameManager.Instance.CheckPlayerHealth();
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










