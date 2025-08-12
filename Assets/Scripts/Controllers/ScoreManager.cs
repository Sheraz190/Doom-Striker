using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    #region Variables
    public int score;
    public int highScore=0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;
  

    #endregion


    private void Start()
    {
        instance = this;
    }

    public void SetHighScore()
    {
        if(score>highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            highScore = PlayerPrefs.GetInt("HighScore", 0);
        }
    }



    //public void TestMethod()
    //{
    //    PlayerPrefs.SetInt("HighScore", 75);
    //    PlayerPrefs.Save();
    //    highScore = PlayerPrefs.GetInt("HighScore", 0);
    //    Debug.Log("High Score after testing is : " + highScore);
    //}

    public  int  GetHighScore()
    {
        return highScore;
    }



    //private void GetHighScore()
    //{
    //    highScore = PlayerPrefs.GetInt("HighScore", 0);
    //}

    //public void DisplayScore()
    //{
    //    scoreText.text = "Score  is " + score;
    //    DislpayHighScore();
    //}

    //public void SetHighScore()
    //{
    //    if(score>highScore)
    //    {
    //        highScore = score;
    //        PlayerPrefs.SetInt("HighScore", highScore);
    //    }
    //}

    //private void DislpayHighScore()
    //{
    //    GetHighScore();
    //    highscoreText.text = "High Score: " + highScore;
    //}
}
