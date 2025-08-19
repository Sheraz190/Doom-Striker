using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    #region Variables
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject GamePlayScreen;
    [SerializeField] private GameObject EndScreen;
    [SerializeField] private GameObject Enviroment;
    [SerializeField] private RectTransform joystick;
    public bool firstTime = true;
    public GameObject fireParticle;
    public GameObject bloodParticle;
    #endregion

    private void Start()
    {
        Instance = this;
        firstTime = true;
    }


    public IEnumerator SpawnParticles()
    { 
        fireParticle.gameObject.SetActive(true);
        yield return  new WaitForSeconds(0.3f);
        fireParticle.gameObject.SetActive(false);
    }


    public void GameEndMethod()
    {
        GamePlayScreen.SetActive(false);
        ScoreManager.instance.ResetScore();
        ScoreManager.instance.UpdateScore();
        PlayerController.Instance.ResetPlayerHealth();
        Enemy.instance.ResetEnemy();
        Enviroment.SetActive(false);
        EndScreen.SetActive(true);
        joystick.anchoredPosition = Vector2.zero;
        EnemySpawner.Instance.ClearEnemies();      
        PlayerController.Instance.StopMoving();
    }


    public void BackButton()
    {
        GamePlayScreen.SetActive(false);
        ScoreManager.instance.ResetScore();
        ScoreManager.instance.UpdateScore();
        PlayerController.Instance.ResetPlayerHealth();
        Enemy.instance.ResetEnemy();
        Enviroment.SetActive(false);
        joystick.anchoredPosition = Vector2.zero;
        EnemySpawner.Instance.ClearEnemies();
        PlayerController.Instance.StopMoving();
    }


    public void ResetGame()
    {
        StartCoroutine(AllowPlayerToMove());
        GamePlayPanel.Instance.ResetBullets();
       StartCoroutine(BulletController.Instance.InstantiateBullets());
    }


    public void ResetforBack()
    {
        if (firstTime)
        {
            firstTime = false;
            return;
        }
          
        else if(!firstTime)
        {
            StartCoroutine(AllowPlayerToMove());
            GamePlayPanel.Instance.ResetBullets();
            StartCoroutine(BulletController.Instance.InstantiateBullets());
        }
       
    }
  
    private IEnumerator AllowPlayerToMove()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerController.Instance.canMove = true;
    }
       
    public void ExitGame()
    {
        Debug.Log("Game application exit");
        Application.Quit();
    }

}