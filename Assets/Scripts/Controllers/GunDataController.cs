using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDataController : MonoBehaviour
{
    #region Variables
    public static GunDataController Instance;
    public GunController Guncontroller;
    private GunProperties currentGun;
    public int bulletCount;
    private float fireRate;
    private float reloadTime;
    private float damage;
    #endregion

    private void Start()
    {
        Instance = this;
        GetGunData(GunsTypes.SMG);
    }

    public void GetGunData(GunsTypes type)
    {
        currentGun = Guncontroller.GetGun(type);
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
