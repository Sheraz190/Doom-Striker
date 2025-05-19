using System.Collections.Generic;
using UnityEngine;
using System;

public enum EnemyType
{
    None = 0,
    Grunt = 1,
    Sergeant = 2,
    Lieutenant = 3,
    Commander = 4
}

[Serializable]
public class EnemyPresetsValues
{
    public EnemyType enemyType = EnemyType.None;
    public int health;
    public int scoreCountOnKill;
    public int enemyHitValue;
 }

[CreateAssetMenu(fileName = "EnemyPresets", menuName = "Game/EnemyPresets", order = 1)]

public class EnemyPreset : ScriptableObject
{
    public List<EnemyPresetsValues> enemyPresets;

    public EnemyPresetsValues GetEnemyData(EnemyType enemyType)
    {
        for (int i = 0; i < enemyPresets.Count; i++)
        {
            if (enemyPresets[i].enemyType == enemyType)
            {
                return enemyPresets[i];
            }
        }
        return null;
    }


}
