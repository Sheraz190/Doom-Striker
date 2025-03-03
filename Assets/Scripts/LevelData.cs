using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyData
{
    public int levelNumber;
    public int enemyCount;
    public int enemyHealth;
    public float spawnRate;
}

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/LevelData",order =1)]

public class LevelData : ScriptableObject
{
   
    public List<EnemyData> enemyData;

    public void GetEnemyStatsbyLevel()
    {
      
    }
       
}
