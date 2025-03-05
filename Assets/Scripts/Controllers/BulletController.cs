using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int bulletCount = 10;
    [SerializeField] private GameObject player;
    [SerializeField] private float bulletSpeed = 500f;
    [SerializeField] private Transform gunPos;
    private float direction = 0.0f;
    private List<GameObject> pooledBullets;

    #endregion

    private void Start()
    {
        InstantiateBullets();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
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
        if (player.transform.localScale.x < 0)
        {
            direction = -1;
        }
        else if (player.transform.localScale.x > 0)
        {
            direction = 1;
        }
    }
    public void FireBullet()
    {
        BulletSpawn();
    }

    private void BulletSpawn()
    {
        GetDirection();
        Vector3 spawnPosition = gunPos.position;

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
                    rb.velocity = new Vector2(direction * bulletSpeed * 0.5f, 0);
                }

                return;
            }
        }
    }

    public void ReloadGun()
    {

    }
}
