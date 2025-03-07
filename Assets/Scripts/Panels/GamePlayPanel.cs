using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayPanel : MonoBehaviour
{
    public static GamePlayPanel Instance;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private GameObject emptyShell;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPanel;
    public List<GameObject> inst_Bullets=new List<GameObject>();

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
        Vector2 spawnPos = new Vector2(-100, 0);
        for (int i = 0; i < bulletCount; i++)
        {
           GameObject emptyobj= Instantiate(emptyShell,bulletPanel);
            GameObject bullet= Instantiate(bulletPrefab, bulletPanel);
            RectTransform rect = emptyobj.GetComponent<RectTransform>();
            RectTransform bulletRect = bullet.GetComponent<RectTransform>();
            rect.anchoredPosition = spawnPos;
            bulletRect.anchoredPosition = spawnPos;
            spawnPos.x += 24;
            inst_Bullets.Add(bullet);
        }
    }
}