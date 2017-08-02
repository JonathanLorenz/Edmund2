using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMenu : MonoBehaviour
{
    public GameObject quitConfirmationPanel;

    private void Awake()
    {
        quitConfirmationPanel.SetActive(false);
    }

    public void showQuitPanel()
    {
        quitConfirmationPanel.SetActive(true);
    }

    public void hideQuitPanel()
    {
        quitConfirmationPanel.SetActive(false);
    }

    public void QuitApp()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
