using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    private GameObject player;
    private int pos = 12;
     void Start()
     {
        player = GameObject.Find("Player");
        StartCoroutine(Spawn(5.0f));
     }

    void Update()
    {
        MoveEnemy();
    }

   
    public IEnumerator Spawn(float delay)
    {
        yield return new WaitForSeconds(delay);
      Instantiate(enemy, new Vector2(pos, 0), Quaternion.identity);
        yield return new WaitForSeconds(delay-1.0f);
        Instantiate(enemy, new Vector2(-pos, 0), Quaternion.identity);

    }

    void MoveEnemy()
    {
        Vector2 targetPos = player.transform.position;
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position,0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}