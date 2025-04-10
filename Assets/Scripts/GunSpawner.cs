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
        //StartCoroutine(SpawnGun());
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
        FetchData();
        //GameObject Inst_Gun = Instantiate(gun, gunSpawnPos, Quaternion.identity, Player.transform);
        //SettingChildFirePos(Inst_Gun);
        gunScale = gun.transform.localScale;
    }

    private void FetchData()
    {
        gun = GunController.Instance.gunPrefab;
        gunSpawnPos = BulletController.Instance.gunPos.position;
    }

    private void SettingChildFirePos(GameObject inst_gun)
    {
        FirePos.transform.SetParent(inst_gun.transform);
        FirePos.transform.localPosition = GunController.Instance.firePos;
    }
}
