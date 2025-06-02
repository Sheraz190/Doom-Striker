using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DropDownController : MonoBehaviour
{
    public static DropDownController Instance;
    #region Variables/GameObjects 

    public TMP_Dropdown dropDown;
    
    #endregion

    private void Start()
    {
        Instance = this;
        dropDown.value = 0;
        dropDown.onValueChanged.AddListener(MethodOnValueChanged);
    }

    void MethodOnValueChanged(int index)
    {
        GunSpawner.Instance.ChangeGun(index);
    }
}
