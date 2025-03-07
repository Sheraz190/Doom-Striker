using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayPanel : MonoBehaviour
{
    public static GamePlayPanel Instance;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private TextMeshProUGUI magazineText;

    private void Start()
    {
        Instance = this;
    }
    public void DisplayHealth()
    {
       playerHealthText.text = "Health: " + PlayerController.Instance.Health;
    }

    public void DisplayMagazine(int bulletCount)
    {
        magazineText.text = "";
        for(int i=0;i<bulletCount;i++)
        {
            magazineText.text += '|';
        } 
    }






 
}
