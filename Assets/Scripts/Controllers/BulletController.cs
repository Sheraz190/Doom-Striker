using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BulletController : MonoBehaviour
{
    public static BulletController Instance;

    #region Variables/Game Objects 

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 500f;
    [SerializeField] private GameObject BulletContainer;

    public int bulletCount;
    public Transform gunPos;
    private Vector3 spawnPosition;
    private List<GameObject> pooledBullets;

    private bool canShoot = true;
    private float direction = 0.0f;
   

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
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            FireBullet();
        }
    }
    private IEnumerator InstantiateBullets()
    {

        yield return new WaitForSeconds(0.5f);
        bulletCount = GunController.Instance.bulletCount;
        pooledBullets = new List<GameObject>();
        Vector3 spawnPosition = player.transform.position;

        for (int i = 0; i < 30; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity, BulletContainer.transform);
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
        if (bulletCount != 0 && canShoot)
        {
            StartCoroutine(BulletSpawn());
        }
    }

    private IEnumerator BulletSpawn()
    {
        canShoot = false;
        yield return new WaitForSeconds(GunController.Instance.fireRate);
        GetDirection();
        CheckingActivePooledBullet();
        canShoot = true;
    }


    private void CheckingActivePooledBullet()
    {
        for (int i = 0; i < GunController.Instance.bulletCount; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                GameObject bullet = pooledBullets[i];
                SetBulletSpawnPosition(bullet);
                bullet.SetActive(true);
                SetBulletCount();
                MovingBullet(bullet);
                break;
            }
        }
    }

    private void SetBulletSpawnPosition(GameObject bullet)
    {
        spawnPosition = new Vector3(GunSpawner.Instance.FirePos.transform.position.x, GunSpawner.Instance.FirePos.transform.position.y, 0);
        bullet.transform.position = spawnPosition;
    }

    private void SetBulletCount()
    {
        bulletCount--;
        DeleteBullet(bulletCount);
        ChecktoReload();
    }

    private void MovingBullet(GameObject bullet)
    {
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(direction * bulletSpeed * 2.5f, 0);
        }
    }

    private void DeleteBullet(int bulletcount)
    {
        for (int i = 0; i < GamePlayPanel.Instance.inst_Bullets.Count; i++)
        {
            if (GamePlayPanel.Instance.inst_Bullets[i].gameObject.activeInHierarchy)
            {
                GamePlayPanel.Instance.inst_Bullets[i].gameObject.SetActive(false);
                break;

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

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(GunController.Instance.reloadTime);
        DeactivatingPooledBullets();
        bulletCount = GunController.Instance.bulletCount;
        GamePlayPanel.Instance.ReloadBullets(bulletCount);
    }

    public void DeactivatingPooledBullets()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            if (pooledBullets[i].activeInHierarchy)
            {
                pooledBullets[i].gameObject.SetActive(false);
            }
        }
    }
}
