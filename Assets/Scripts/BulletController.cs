using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int bulletCount = 10;
    [SerializeField] private GameObject player;
    [SerializeField] private float bulletSpeed = 10f;
    private float direction = 0.0f;
    private Vector3 bulletPosition;
    private List<GameObject> pooledBullets;

    #endregion

    private void Start()
    {
        InstantiateBullets();
    }

    private void InstantiateBullets()
    {
        pooledBullets = new List<GameObject>();
        Vector3 spawnPosition = player.transform.position;

        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            bullet.SetActive(false);
            pooledBullets.Add(bullet);
        }
    }

    private void GetDirection()
    {

        direction = 1;
        bulletPosition = new Vector3(1.5f, 0.15f, 0);
        if (player.transform.localScale.x < 0)
        {
            bulletPosition = new Vector3(-1.5f, -0.15f, 0);
            direction = -1;
        }

    }
    public void FireBullet()
    {
         GetDirection();
        Vector3 spawnPosition = player.transform.position+ bulletPosition;

        for (int i = 0; i < bulletCount; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                GameObject bullet = pooledBullets[i];
                bullet.transform.position = spawnPosition;
                bullet.SetActive(true);

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = new Vector2(direction * bulletSpeed, 0);
                }

                return;
            }
        }
        ResetBullets();
    }

    private void ResetBullets()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            if (pooledBullets[i].activeInHierarchy)
            {
                pooledBullets[i].SetActive(false);
            }
        }
    }

    
}
