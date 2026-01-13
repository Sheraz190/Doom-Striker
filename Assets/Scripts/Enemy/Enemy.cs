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
    private Vector3 hitPosition;



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

    public int GetPlayerSide()
    {
        if (player == null) return 0;

        if (player.transform.position.x < transform.position.x)
        {
            // Player is on the left side
            return -1;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            // Player is on the right side
            return 1;
        }
        else
        {
            // Player is exactly aligned on X
            return 0;
        }
    }

    public void SetDirection()
    {

        int side = GetPlayerSide();

        if (side == -1)
        {
            transform.localScale = new Vector2(-originalScale.x, originalScale.y);
        }
        else if (side == 1)
        {
            transform.localScale = new Vector2(originalScale.x, originalScale.y);
        }
        else
        {
            Debug.Log("Player is directly aligned with enemy");
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
            hitPosition = collision.contacts[0].point;
        }
        if (collision.gameObject.CompareTag("Player") )
        {
            ApplyForceonEnemy();
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
           // Destroy(gameObject);
        }
    }
        
    private void ApplyForceonEnemy()
    {
        //Vector2 bounceDirection = (transform.position - player.transform.position).normalized;
        // rb.velocity = Vector2.zero;
        //rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);

        // transform.Translate(-Time.deltaTime, 0, 0);
        float direction = (transform.position.x < player.transform.position.x) ? -1f : 1f;
        transform.position = new Vector3(transform.position.x + (2.5f * direction),transform.position.y,0);
    }

    private void TakeDamage()
    {
        health -= GunController.Instance.damage;
        
        if (health <= 0&&health>0- GunController.Instance.damage)
        {
            GameManager.Instance.enemiesKilled++;
            StartCoroutine(ApplyBloodParticle());
            if(GameManager.Instance.enemiesKilled<GameManager.Instance.currentLevel)
            {
                StartCoroutine(WaitTime());
                EnemySpawner.Instance.SpawnEnemies();
                ScoreManager.instance.score += 50;
                ScoreManager.instance.UpdateScore();
                ScoreManager.instance.SetHighScore();
            }
        }
    }

    private IEnumerator ApplyBloodParticle()
    {
        touchPlayer = true;
        GameManager.Instance.bloodParticle.transform.position = hitPosition;
        GameManager.Instance.bloodParticle.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        GameManager.Instance.bloodParticle.SetActive(false);
    }



    public void ResetEnemy()
    {
        Destroy(gameObject);
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.3f);
    }

    public void ResetEnemyData()
    {
        health = 10;
        SetDirection();
    }
}