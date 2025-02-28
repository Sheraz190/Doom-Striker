using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameContstants.DoomStrikerEnums;

public class UIPopupParentClass : MonoBehaviour
{
    public PopupTypes popupType = PopupTypes.None;
    public GameObject mainPanel;
    [HideInInspector] public bool isPopupOpen = false;


    public virtual void OpenPopup()
    {
        if (mainPanel != null)
        {
            mainPanel.SetActive(true);
            isPopupOpen = true;
        }
    }

    public virtual void ClosePopup()
    {
        mainPanel.SetActive(false);
        isPopupOpen = false;
    }
}
