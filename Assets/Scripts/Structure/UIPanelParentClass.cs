using UnityEngine;
using static GameContstants.DoomStrikerEnums;

public class UIPanelParentClass : MonoBehaviour
{
    public PanelTypes panelType = PanelTypes.None;
    public GameObject mainPanel;
    [HideInInspector] public bool isPanelOpen = false;


    public virtual void OpenPanel()
    {
        if(mainPanel != null)
        {
            mainPanel.SetActive(true);
            isPanelOpen = true;
        }
    }

    public virtual void ClosePanel()
    {
        mainPanel.SetActive(false);
        isPanelOpen = false;
    }
}
