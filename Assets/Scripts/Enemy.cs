using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Game objects/ Variables

    public static Enemy instance;
    private bool touchPlayer = false;
    public GameObject enemy;
    private EnemyPresetsValues currentEnemy;
    private GameObject player;
    [Space, Header("Variables")]
    private float health;
    private Vector2 originalScale;

    #endregion

    private void Start()
    {
        player = GameObject.Find("Player");
        originalScale = transform.localScale;
        instance = this;
        SetDirection();
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

    public void SetDirection()
    {
        if(gameObject.transform.localPosition.x>-348)
        {
            transform.localScale = new Vector2(-originalScale.x, originalScale.y);
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