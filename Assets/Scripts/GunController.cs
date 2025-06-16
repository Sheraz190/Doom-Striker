using UnityEngine;

public class GunController : MonoBehaviour
{
    public static GunController Instance;
    #region Variables

    [SerializeField]private  GunDataController gunDataController;
    public GameObject bullet;
    public GameObject gunPrefab;
    private GunProperties currentGun;

    public Vector3 firePos;

    public int bulletCount;
    public bool canbrustFire;
    public float damage;
    public float fireRate;
    public float reloadTime;
    public bool brustFire;

    #endregion

    private void Start()
    {
        Instance = this;
        GamePlayPanel.Instance.DisplayShells(bulletCount);

    }

    private void Awake()
    {
        GetGunData(0);
    }

    public void GetGunData(int index)
    {
        currentGun = gunDataController.GetGun(index);
        damage = currentGun.Damage;
        firePos = currentGun.firepos;
        fireRate = currentGun.FireRate;
        gunPrefab = currentGun.GunPrefab;
        reloadTime = currentGun.ReloadTime;
        bulletCount = currentGun.BulletCount;
        brustFire = currentGun.brustFire;
        
    }
}
