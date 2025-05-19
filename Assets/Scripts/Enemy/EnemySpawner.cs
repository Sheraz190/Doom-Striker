using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    #region Game objects

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;
    public List<GameObject> pooledObjects = new List<GameObject>();
    
    [Space, Header("Variables")]

    private int enemyCount = 5;
    private int direction = 12;

    #endregion

    private void Start()
    {
        Instance = this;
        GetEnemyData();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        int i = 0;
        while (i<enemyCount)
        {
            GameObject temp_obj;
            yield return new WaitForSeconds(EnemyDataHandler.instance.SpawnRate);
            SelectDirection();
            temp_obj = Instantiate(enemyPrefab, new Vector2(direction, 0), Quaternion.identity, enemyContainer.transform.transform);
            i++;
        }
    }

    private void SpawningEnemies()
    { 
        
    }


    private void SelectDirection()
    {
        float num = Random.Range(0, 10);

        if (num < 5)
        {
            direction = 11;
        }
        else
        {
            direction = -11;
        }
    }

    private void GetEnemyData()
    {
        enemyCount = EnemyDataHandler.instance.EnemyCount;
    }
}
