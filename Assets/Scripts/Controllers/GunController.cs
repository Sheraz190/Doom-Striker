using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GunsTypes
{
    None=0,
    Pistol=1,
    Revolver=2,
    SMG=3,
    Shotgun=4,
    Assault_Rifle=5,
    Battle_Rifle=6,
    Pump_Action_Shotgun=7,
    LMG =8,
    HMG=9,
    RPG=10

}

[Serializable]
public class GunProperties
{
    public GunsTypes GunType;
    public int BulletCount;
    public float FireRate;
    public float ReloadTime;
    public float Damage;
}

[CreateAssetMenu(fileName ="Guns Properties",menuName ="Game/Guns Properties")]


public class GunController : ScriptableObject
{

    public List<GunProperties> gunTypeProperty;

    public GunProperties GetGun(GunsTypes type)
    {
        for (int i = 0; i < gunTypeProperty.Count; i++)
        {
            if (gunTypeProperty[i].GunType == type)
            {
                return gunTypeProperty[i];
            }
        }
        return null;
    }

}
