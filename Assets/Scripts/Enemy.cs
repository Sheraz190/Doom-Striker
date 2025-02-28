using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Game objects

    private EnemyController enemyController;
    public GameObject enemy;
    private GameObject player;
    public Rigidbody rb;
    #endregion

    private void Start()
    {
        player = GameObject.Find("Player");


    }

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector2 targetPos = player.transform.position;
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, 0.05f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
}