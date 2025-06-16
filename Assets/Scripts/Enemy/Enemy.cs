using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    #region Game objects/ Variables

    public GameObject enemy;
    private GameObject player;

    private Vector2 originalScale;

    private float health;
    private bool touchPlayer = false;
    
    


    #endregion

    private void Start()
    {
        player = GameObject.Find("Player");
        originalScale = transform.localScale;
        health = 10;
        instance = this;
        SetDirection();
    }

    private void OnEnable()
    {
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
        if (gameObject.transform.localPosition.x > -348)
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
            Destroy(gameObject);
            StartCoroutine(WaitTime());
            EnemySpawner.Instance.SpawnEnemies();
        }
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
    }

    public void ResetEnemyData()
    {
        health = 10;
        SetDirection();
    }
}