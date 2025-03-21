using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region Variables
    public static BulletController Instance;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int bulletCount;
    [SerializeField] private GameObject player;
    [SerializeField] private float bulletSpeed = 500f;
    [SerializeField] private GameObject BulletContainer;
   
    private Vector3 spawnPosition;
    public Transform gunPos;
    private bool canShoot = true;
    private float direction = 0.0f;
    private List<GameObject> pooledBullets;

    #endregion

    private void Start()
    {
        Instance = this;
        StartCoroutine(InstantiateBullets());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }
    private IEnumerator InstantiateBullets()
    {
        yield return new WaitForSeconds(0.5f);
        bulletCount = GunController.Instance.bulletCount;
        pooledBullets = new List<GameObject>();
        Vector3 spawnPosition = player.transform.position;

        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity,BulletContainer.transform);
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
        if (bulletCount != 0&&canShoot)
        {
            StartCoroutine(BulletSpawn());
        }
    }

    private IEnumerator BulletSpawn()
    {
        canShoot = false;
        yield return new WaitForSeconds(GunController.Instance.fireRate);
        
        GetDirection();

        for (int i = 0; i < GunController.Instance.bulletCount; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                GameObject bullet = pooledBullets[i];
                spawnPosition = new Vector3(GunSpawner.Instance.FirePos.transform.position.x, GunSpawner.Instance.FirePos.transform.position.y,0);
                bullet.transform.position = spawnPosition;
                bullet.SetActive(true);
                bulletCount--;
                DeleteBullet(bulletCount);
                ChecktoReload();
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = new Vector2(direction * bulletSpeed * 2.5f, 0);
                }
                break;    
            }
        }
        canShoot = true;
    }

    private void DeleteBullet(int bulletcount)
    {
        for (int i = GamePlayPanel.Instance.inst_Bullets.Count - 1; i >= 0; i--)
        {
            if (i >= bulletcount)
            {
                if (GamePlayPanel.Instance.inst_Bullets[i].gameObject.activeInHierarchy)
                {
                    GamePlayPanel.Instance.inst_Bullets[i].gameObject.SetActive(false);
                }
            }
        }
    }


    private void ChecktoReload()
    {
        if (bulletCount == 0)
        {
            StartCoroutine(Reload());    
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(GunController.Instance.reloadTime);
        ResetBullet();
        GamePlayPanel.Instance.inst_Bullets.Clear();
        GamePlayPanel.Instance.DisplayShells(GunController.Instance.bulletCount);
        bulletCount = GunController.Instance.bulletCount;
    }

    private void ResetBullet()
    {
        for(int i=0;i<pooledBullets.Count;i++)
        {
            if(pooledBullets[i].activeInHierarchy)
            {
                pooledBullets[i].gameObject.SetActive(false);
            }
        }
    }
}
