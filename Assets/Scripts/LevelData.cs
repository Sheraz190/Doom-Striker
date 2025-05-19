using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class EnemyData
{
    public int levelNumber;
    public EnemyType enemyType;
    public int enemyCount;
    public float spawnRate;
}

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/LevelData", order = 1)]

public class LevelData : ScriptableObject
{
    public List<EnemyData> enemyData;

    public EnemyData GetLevelData(int index)
    {

        for (int i = 0; i < enemyData.Count; i++)
        {
            if (enemyData[i].levelNumber == index)
            {
                Debug.Log("Level number: " + enemyData[i].levelNumber);
                return enemyData[i];
            }
        }
        return null;
    }
}
