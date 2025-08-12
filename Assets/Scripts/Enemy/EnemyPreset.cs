using System.Collections.Generic;
using UnityEngine;
using System;

public enum EnemyType
{
    None = 0,
    Chicken = 1,
    Bunny = 2,
    Rino = 3,
    Turtle = 4,
    Chameleon=5
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
