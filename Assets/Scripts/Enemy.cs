using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Game objects/ Variables

    private EnemyController enemyController;
    public GameObject enemy;
    private GameObject player;
    public Rigidbody rb;
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
        Vector2 targetPos = player.transform.position;
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, 0.03f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
            collision.gameObject.SetActive(false);
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
        health = Random.Range(3, 5);
    }
}