using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController ECInstance;
    public List<GameObject> pooledObjects;
    private GameObject temp_obj;
    public GameObject enemyPrefab;
    private int enemyCount = 5;

     void Start()
     {
        ECInstance = this;
        for(int i=0;i<enemyCount;i++)
        {
            temp_obj=Instantiate(enemyPrefab);
            temp_obj.SetActive(false);
            pooledObjects.Add(temp_obj);
        }

     }

    public GameObject GetPooledObjects()
    {
        for(int i=0;i<enemyCount;i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }


}
