using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    #region Game objects
    private List<GameObject> pooledObjects;
    public GameObject enemyPrefab;

    [Space, Header("")]
    [SerializeField] private int enemyCount = 5;
    private int direction = 12;

    #endregion

    private void Start()
    {
        Instance = this;
        CreatePoolObjects();
        StartCoroutine(SpawnEnemies());
    }

    private void CreatePoolObjects()
    {
        GameObject temp_obj;
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < enemyCount; i++)
        {
            SelectDirection();
            temp_obj = Instantiate(enemyPrefab, new Vector2(direction, 0), Quaternion.identity);
            temp_obj.SetActive(false);
            pooledObjects.Add(temp_obj);
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            GameObject temp_obj;
            yield return new WaitForSeconds(3.0f);
            temp_obj = GetPooledObjects();
            SelectDirection();
            temp_obj.transform.position = new Vector2(direction, 0);
            temp_obj.SetActive(true);
        }
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

    private GameObject GetPooledObjects()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }

        }

        return null;
    }
}
