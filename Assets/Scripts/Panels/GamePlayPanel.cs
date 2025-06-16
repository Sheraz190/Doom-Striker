using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayPanel : MonoBehaviour
{
    public static GamePlayPanel Instance;

    #region Variables 
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private GameObject emptyShell;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPanel;
    public List<GameObject> inst_Bullets = new List<GameObject>();
    public List<GameObject> inst_Shells = new List<GameObject>();

    #endregion


    private void Start()
    {
        Instance = this;
    }
    public void DisplayHealth()
    {
        playerHealthText.text = "Health: " + PlayerController.Instance.Health;
    }

    public void DisplayShells(int bulletCount)
    {
        Vector2 spawnPos = new Vector2(-100, -20);
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject emptyobj = Instantiate(emptyShell, bulletPanel);
            GameObject bullet = Instantiate(bulletPrefab, bulletPanel);
            RectTransform rect = emptyobj.GetComponent<RectTransform>();
            RectTransform bulletRect = bullet.GetComponent<RectTransform>();
            rect.anchoredPosition = spawnPos;
            bulletRect.anchoredPosition = spawnPos;
            spawnPos.x += 40;
            inst_Bullets.Add(bullet);
            inst_Shells.Add(emptyobj);
        }
    }


    public void ResetBullets()
    {
        DeactivateBullets();
        DisplayShells(GunController.Instance.bulletCount);
    }


    private void DeactivateBullets()
    {
        for (int i = 0; i < inst_Bullets.Count||i<inst_Shells.Count; i++)
        {
            if (inst_Bullets[i].activeInHierarchy)
            {
                inst_Bullets[i].gameObject.SetActive(false);
            }
            if (inst_Shells[i].activeInHierarchy)
            {
                inst_Shells[i].gameObject.SetActive(false);
            }
        }
    }


    public void ReloadBullets(int count)
    {
        DeactivateBullets();
        for (int i = 0; i < count ; i++)
        {
            if (!inst_Bullets[i].activeInHierarchy)
            {
                inst_Bullets[i].gameObject.SetActive(true);
            }
            if (!inst_Shells[i].activeInHierarchy)
            {
                inst_Shells[i].gameObject.SetActive(true);
            }
        }
    }
}