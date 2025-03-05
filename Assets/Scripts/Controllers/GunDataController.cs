using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDataController : MonoBehaviour
{
    public static GunDataController Instance;
    public GunController gunController;
    private GunProperties currentGun;
    private int bulletCount;
    private float fireRate;
    private float reloadTime;
    private float damage;


    private void Start()
    {
       
        Instance = this;
        GetGunData(GunsTypes.Pistol);
    }


  

    public void GetGunData(GunsTypes type)
    {
        currentGun = gunController.GetGun(type);
        if(currentGun==null)
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

    }

}
