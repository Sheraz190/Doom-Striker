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
    [SerializeField] private TextMeshProUGUI highScoreTextonGamePlay;

    #endregion


    private void Start()
    {
        instance = this;
        score = 0;
       
    }
    private void OnEnable()
    {
        UpdateScore();
        updateHighScoreOnGamePlay();
    }

    public void SetHighScore()
    {
        if(score>highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            updateHighScoreOnGamePlay();
        }
    }

    private void updateHighScoreOnGamePlay()
    {
        highScoreTextonGamePlay.text = "High Score: " + GetHighScore();
    }
   

    public  int  GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        return highScore;
    }



    public void UpdateScore()
    {
        scoreText.text = " ";
        scoreText.text = "Score: "+ score;
       
    }

    public void ResetScore()
    {
        score = 0;
    }


  
}
