using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    #region Variables
    private GameObject gun;
    private Vector2 gunSpawnPos;
  
    #endregion

    private void Start()
    {
        StartCoroutine(SpawnGun());
    }


    private IEnumerator SpawnGun()
    {
        yield return new WaitForSeconds(1.0f);
         gun = GunController.Instance.gunPrefab;
        gunSpawnPos = BulletController.Instance.gunPos.position;
        Instantiate(gun, gunSpawnPos, Quaternion.identity);
    }
}
