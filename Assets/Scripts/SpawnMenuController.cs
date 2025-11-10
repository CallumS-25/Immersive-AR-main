using UnityEngine;
using UnityEngine.Timeline;

public class SpawnMenuController : MonoBehaviour
{

    public GameObject menuPanel;

    public void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
    }

    public void HideMenu()
    {
        menuPanel.SetActive(false);
    }

}
