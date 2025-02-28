using System.Collections;
using System.Collections.Generic;
using static GameContstants.DoomStrikerEnums;
using UnityEngine;
using System;
using UnityEngine.UI;


[Serializable]
public class PanelPreset
{
    public PanelTypes panelType = PanelTypes.None;
    public UIPanelParentClass panelParentObj;
}

[Serializable]
public class PopupPreset
{
    public PopupTypes popupType = PopupTypes.None;
    public UIPopupParentClass popupParentObj;
}

public class SceneUIController : MonoBehaviour
{
    public static SceneUIController Instance;

    [Space, Header("Panels")]
    [SerializeField] private List<PanelPreset> panels = new List<PanelPreset>();

    [Space, Header("Popups")]
    [SerializeField] private List<PopupPreset> popups = new List<PopupPreset>();

    private void Awake()
    {
        Instance = this;
    }

    public void OpenPanel(PanelTypes panelType)
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if(panelType == panels[i].panelType)
            {
                panels[i].panelParentObj.OpenPanel();

                break;
            }
        }
    }

    public void ClosePanel(PanelTypes panelType)
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if (panelType == panels[i].panelType)
            {
                panels[i].panelParentObj.ClosePanel();

                break;
            }
        }
    }

    public void OpenPopup(PopupTypes popupType)
    {
        for (int i = 0; i < popups.Count; i++)
        {
            if (popupType == popups[i].popupType)
            {
                popups[i].popupParentObj.OpenPopup();

                break;
            }
        }
    }

    public void ClosePopup(PopupTypes popupType)
    {
        for (int i = 0; i < popups.Count; i++)
        {
            if (popupType == popups[i].popupType)
            {
                popups[i].popupParentObj.ClosePopup();

                break;
            }
        }
    }
}
