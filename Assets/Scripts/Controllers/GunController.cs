using UnityEngine;

public class GunController : MonoBehaviour
{
    #region Variables
    public static GunController Instance;
   [SerializeField]private  GunDataController gunDataController;
    private GunProperties currentGun;
    public int bulletCount;
    public float fireRate;
    public float reloadTime;
    private float damage;
    #endregion

    private void Start()
    {
        Instance = this;
        GetGunData(PlayerController.Instance.currentGun);
        GamePlayPanel.Instance.DisplayShells(bulletCount);
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
        
    }
}
