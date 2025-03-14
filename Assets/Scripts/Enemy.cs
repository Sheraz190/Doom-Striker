using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Game objects/ Variables

  
    public GameObject enemy;
    private  GameObject player;
    [Space, Header("Variables")]
    private int health;

    #endregion

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnEnable()
    {
        ResetHealth();
    }
    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector2 targetPos = PlayerController.Instance.transform.position;
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, 0.03f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void ResetHealth()
    {
        health = Random.Range(1,3);
    }
}