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
            Vector3 newPos = transform.position;
                newPos.x = -30;
            gameObject.transform.position = newPos;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 newPos = transform.position;
            newPos.x = -30;
            gameObject.transform.position = newPos;
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
