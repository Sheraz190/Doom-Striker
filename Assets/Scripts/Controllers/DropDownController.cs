using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DropDownController : MonoBehaviour
{
    #region Variables/GameObjects 

    [SerializeField] private TMP_Dropdown dropDown;

    #endregion

    private void Start()
    {
        dropDown.value = 0;
        dropDown.onValueChanged.AddListener(MethodOnValueChanged);
    }

    void MethodOnValueChanged(int index)
    {
        GunSpawner.Instance.ChangeGun(index);
    }
}
