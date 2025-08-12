using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartPanel : MonoBehaviour
{
    #region Variables

    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private ScoreManager scoreManager;
    private int highscore=5;

    #endregion

    private void Start()
    {
        DisplayHighScore();
    }

    private void DisplayHighScore()
    {
        if(ScoreManager.instance==null)
        {
            Debug.Log("Instance is null");
        }
        highScoreText.text = "High Score :" + scoreManager.GetHighScore();
    }

}
