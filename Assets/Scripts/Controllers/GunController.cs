using UnityEngine;

public class GunController : MonoBehaviour
{
    #region Variables
    public static GunController Instance;
   [SerializeField]private  GunDataController gunDataController;
    private GunProperties currentGun;
    public int bulletCount;
    private float fireRate;
    private float reloadTime;
    private float damage;
    #endregion

    private void Start()
    {
        Instance = this;
        GetGunData(GunsTypes.Revolver);
    }

    public void GetGunData(GunsTypes type)
    {
        currentGun = gunDataController.GetGun(type);
        if (currentGun == null)
        {
            Debug.Log("gun is empty ");
        }
        bulletCount = currentGun.BulletCount;
        fireRate = currentGun.FireRate;
        reloadTime = currentGun.ReloadTime;
        damage = currentGun.Damage;
        Debug.Log("Bullet count: " + bulletCount);
        Debug.Log("fireRate: " + fireRate);
        Debug.Log("REload: " + reloadTime);
        Debug.Log("Damage: " + damage);
        Debug.Log("Gun Name: " + currentGun.GunType);
    }
}
