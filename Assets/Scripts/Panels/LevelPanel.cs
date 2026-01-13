using UnityEngine;
using System.Collections;

public class LevelPanel : MonoBehaviour
{
    public GameObject textPanel;
    public GameObject GameplayPanel;
    public GameObject enviroment;
    public GameObject levelPanel;

    public void OnLevelSelected(int levelIndex)
    {
        StartCoroutine(OnTextPanel());
        GameManager.Instance.currentLevel = levelIndex;
        Debug.Log("Level is: " + levelIndex);
    }

    private IEnumerator OnTextPanel()
    {
        textPanel.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Method time Complete");
        textPanel.SetActive(false);
        GameplayPanel.SetActive(true);
        enviroment.SetActive(true);
        levelPanel.SetActive(false);
        GameManager.Instance.ResetforBack();
    }
}
