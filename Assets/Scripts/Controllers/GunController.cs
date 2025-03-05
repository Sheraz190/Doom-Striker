using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum guns
{
    None=0,
    Pistol=1,
    Revolver=2,
    SMG=3,
    Shotgun=4,
    Assault_Rifle=5,
    Battle_Rifle=6,
    PumpA_ction_Shotgun=7,
    LMG =8,
    HMG=9,
    RPG=10

}

[Serializable]
public class GunProperties
{
    public guns GunType;
    public int BulletCount;
    public float FireRate;
    public float ReloadTime;
    public float Damage;
}

[CreateAssetMenu(fileName ="Guns Properties",menuName ="Game/Guns Properties")]


public class GunController : ScriptableObject
{

    public List<GunProperties> gunController;

}
