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

    private int direction = 0;
  

    #endregion

    private void Start()
    {
        Instance = this;
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        SelectDirection();
        Instantiate(enemyPrefab, new Vector2(direction, 0), Quaternion.identity, enemyContainer.transform.transform);
    }


    private void SelectDirection()
    {
        float num = Random.Range(0, 10);
        if(num<5)
        {
            direction = -25;
        }
        else
        {
            direction = 25;
        }
    }

}
