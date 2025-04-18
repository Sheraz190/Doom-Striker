using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Game objects/ Variables

    private bool touchPlayer = false;
    public GameObject enemy;
    private EnemyPresetsValues currentEnemy;
    private GameObject player;
    [Space, Header("Variables")]
    private float health;

    #endregion

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnEnable()
    {
        ResetHealth();
        touchPlayer = false;
    }

    private void Update()
    {
        if (!touchPlayer)
        {
            MoveEnemy();
        }
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
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            touchPlayer = true;
        }
    }

    private void TakeDamage()
    {
        health -= GunController.Instance.damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void ResetHealth()
    {
        health = 4;
    }
}