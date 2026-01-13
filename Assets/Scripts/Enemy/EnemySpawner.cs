using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    #region Game objects

    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private GameObject enemyContainer;
    public List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private Transform player;
    private float SpawnTime;
    public int currentLevel;

    [Space, Header("Variables")]

    private int direction = 0;


    #endregion

    private void Start()
    {
        Instance = this;
    }


    private void OnEnable()
    {
        SpawnEnemies();
    }


    private IEnumerator AddTime()
    {
        yield return new WaitForSeconds(1.5f);
    }

    public void SpawnEnemies()
    {
            float num = Random.Range(-10, 10);
            if ((num < 3 && num > 0) || (num > -3 && num < 0))
            {
                num += 6;
            }
            float offsetX = (num < 5) ? -5f : 5f;
            float offsetY = Random.Range(-2f, 2f);

            Vector2 spawnPos = new Vector2(player.position.x + num, player.position.y + 0);
            StartCoroutine(AddTime());
            Instantiate(enemyPrefabs[SelectEnemy()], spawnPos, Quaternion.identity, enemyContainer.transform);
    }


    public void ClearEnemies()
    {
        foreach (Transform child in enemyContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }


    private int SelectEnemy()
    {
        int num = Random.Range(0, enemyPrefabs.Count);
        return num;
    }

    private void SelectDirection()
    {
        float num = Random.Range(0, 10);
        if (num < 5)
        {
            direction = -25;
        }
        else
        {
            direction = 25;
        }
    }

}
