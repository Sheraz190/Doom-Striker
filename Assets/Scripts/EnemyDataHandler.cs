using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataHandler : MonoBehaviour
{
    #region Variables

    public static EnemyDataHandler instance;
    [SerializeField] private EnemyData enemyData;
    private EnemyData currentEnemy;
    public LevelData levelData;
    public int EnemyCount = 0;
    public float SpawnRate = 0.0f;

    #endregion

    private void Start()
    {
        instance = this;
        GetEnemyData(1);
    }


    private void GetEnemyData(int index)
    {
        currentEnemy = levelData.GetLevelData(index);
        EnemyCount = currentEnemy.enemyCount;
        SpawnRate = currentEnemy.spawnRate;
    }

}
