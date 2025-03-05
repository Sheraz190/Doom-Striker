using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayPanel : MonoBehaviour
{
    public static GamePlayPanel Instance;
    [SerializeField] private TextMeshProUGUI playerHealthText;

    private void Start()
    {
        Instance = this;
    }
    public void DisplayHealth()
    {
       playerHealthText.text = "Health: " + PlayerController.Instance.Health;
    }
 
}
