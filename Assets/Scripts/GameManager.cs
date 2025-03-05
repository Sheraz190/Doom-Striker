using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject mobileCanvas;

    private void Start()
    {
        Instance = this;
#if UNITY_EDITOR
        mobileCanvas.gameObject.SetActive(false);
#endif

    }

    public void CheckPlayerHealth()
    {
        Debug.Log("Game ends ");
    }
}
