using System.Collections.Generic;
using UnityEngine;
using System;

public enum GunsTypes
{
    None = 0,
    Pistol = 1,
    shotgun=2,
    Airgun=3,
    Assault=4
}

[Serializable]
public class GunProperties
{
    public GunsTypes GunType;
    public GameObject GunPrefab;

    public int GunIndex;
    public int BulletCount;
    public float Damage;
    public float FireRate;
    public float ReloadTime;
    public bool brustFire;
    public Vector3 firepos = new Vector3(0, 0, 0);
}

[CreateAssetMenu(fileName = "Guns Properties", menuName = "Game/Guns Properties")]

public class GunDataController : ScriptableObject
{
    public List<GunProperties> gunTypeProperty;

    public GunProperties GetGun(int index)
    {
        for (int i = 0; i < gunTypeProperty.Count; i++)
        {
            if (gunTypeProperty[i].GunIndex == index)
            {
                return gunTypeProperty[i];
            }
        }
        return null;
    }
}

