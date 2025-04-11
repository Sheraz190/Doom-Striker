using UnityEngine;

public class GunController : MonoBehaviour
{
    #region Variables
    public static GunController Instance;
   [SerializeField]private  GunDataController gunDataController;
    private GunProperties currentGun;
    public GameObject gunPrefab;
    public GameObject bullet;
    public Vector3 firePos;
    public int bulletCount;
    public float fireRate;
    public float reloadTime;
    public float damage;
    #endregion

    private void Start()
    {
        Instance = this;
        GetGunData(0);
        GamePlayPanel.Instance.DisplayShells(bulletCount);
    }

    public void GetGunData(int index)
    {
        currentGun = gunDataController.GetGun(index);
        bulletCount = currentGun.BulletCount;
        fireRate = currentGun.FireRate;
        reloadTime = currentGun.ReloadTime;
        damage = currentGun.Damage;
        gunPrefab = currentGun.GunPrefab;

    }
}
