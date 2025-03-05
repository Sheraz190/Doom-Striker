using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables
    private Vector2 bulletOriginalScale;
    #endregion
    private void Start()
    {
        bulletOriginalScale = transform.localScale;
    }
    private void Update()
    {
        ChangeDirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SideCollider"))
        {
            gameObject.SetActive(false);
        }
    }

    private void ChangeDirection()
    {
        if (PlayerController.Instance.player.transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(-bulletOriginalScale.x, -bulletOriginalScale.y);
        }
        else if (PlayerController.Instance.player.transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(bulletOriginalScale.x, bulletOriginalScale.y);
        }
    }
}
