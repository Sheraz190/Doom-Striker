using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LevelPresetData
{
    public int levelNumber;
    public List<EnemyData> enemyList;
}

// anther class contain enemy type and count
[Serializable]
public class EnemyData
{
    public EnemyType enemyType;
    public int enemyCount;
    public float spawnRate;
}

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/LevelData",order =1)]

public class LevelData : ScriptableObject
{
   public List<LevelPresetData> enemyData;
}
