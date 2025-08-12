using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int playerHealth;
    [SerializeField]private GameObject GamePlayScreen;
    [SerializeField]private GameObject EndScreen;


    private void Start()
    {
        Instance = this;
        playerHealth = 10;
       
    }

    public void CheckPlayerHealth()
    {
        if(playerHealth<1)
        {
            Debug.Log("Game ends ");
            GameEndMethod();
        }
    }


  
    public void ActionstoTakeOnEnemyCollision()
    {
        playerHealth--;
        CheckPlayerHealth();
        DisplayPlayerHealth();
    }

    private void DisplayPlayerHealth()
    {
        healthText.text = "Player health: " + playerHealth;
    }

    private void GameEndMethod()
    {
        GamePlayScreen.SetActive(false);
        EndScreen.SetActive(true);
    }




}
