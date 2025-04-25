using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    #region Game objects

    private List<GameObject> pooledObjects;
    [SerializeField]private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;
    [Space, Header("Variables")]
    [SerializeField] private int enemyCount = 5;
    private int direction = 12;
    private Vector2 originalScale;


    #endregion

    private void Start()                
    {
        Instance = this;
        CreatePoolObjects();
        StartCoroutine(SpawnEnemies());
        Transform enemyTransform = enemyPrefab.transform;
    }

    private void CreatePoolObjects()
    {
        GameObject temp_obj;
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < enemyCount; i++)
        {
            SelectDirection();
            temp_obj = Instantiate(enemyPrefab, new Vector2(direction, 0), Quaternion.identity,enemyContainer.transform.transform);
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


    //private void SetEnemyDirection(int direction)
    //{
    //    Transform enemyTransform = enemyPrefab.transform;
    //    Vector3 scale = enemyTransform.localScale;
    //    if (direction > 0)
    //    {
    //        scale.x = -scale.x;
    //        Debug.Log(" " + enemyPrefab.transform.localScale);
    //        Debug.Log("- scale function called");
    //    }
    //    else
    //    {
    //        scale.x = Mathf.Abs(scale.x);
    //    }
    //}
   

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
