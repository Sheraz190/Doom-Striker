using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    #region Variables
    public static GunSpawner Instance;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject Player;
    public GameObject FirePos;
    private Vector2 gunSpawnPos;
    private Vector2 gunScale;
    #endregion

    private void Start()
    {
        Instance =this;
        StartCoroutine(SpawnGun());
    }

    private void Update()
    {
        if (Player.transform.localScale.x < 0)
        {
            gun.transform.localScale = gunScale;
        }
        else if (Player.transform.localScale.x > 0)
        {
            gun.transform.localScale = gunScale;
        }
    }


    private IEnumerator SpawnGun()
    {
        yield return new WaitForSeconds(1.0f);
        gun = GunController.Instance.gunPrefab;
        gunSpawnPos = BulletController.Instance.gunPos.position;
        GameObject Inst_Gun = Instantiate(gun, gunSpawnPos, Quaternion.identity, Player.transform);
        FirePos.transform.SetParent(Inst_Gun.transform);
        FirePos.transform.localPosition =GunController.Instance.firePos;
        gunScale = gun.transform.localScale;
      
    }
}
