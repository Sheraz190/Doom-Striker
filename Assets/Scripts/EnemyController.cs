using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;

    #region Game objects
    [Space, Header("Lists")]
    private List<GameObject> pooledObjects;
    public GameObject enemyPrefab;
    #endregion

    #region Variables
    [SerializeField] private int enemyCount = 5;
    #endregion

    private void Start()
    {
        Instance = this;
        CreatePoolObjects();
    }

    private void CreatePoolObjects()
    {
        GameObject temp_obj;

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < enemyCount; i++)
        {
            temp_obj = Instantiate(enemyPrefab, new Vector2(12, 0), Quaternion.identity);
            temp_obj.SetActive(false);
            pooledObjects.Add(temp_obj);
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


    public void StartSpawning()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject temp_obj = GetPooledObjects();
            temp_obj.SetActive(true);
        }
    }
}
