using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PauseButton;
    public GameObject UI;
    private bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (paused) Continue(); else Pause();
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        PauseButton.SetActive(false);
        UI.SetActive(false);
        
        Time.timeScale = 0;
        paused = true;
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        PauseButton.SetActive(true);
        UI.SetActive(true);
        Time.timeScale = 1;
        paused = false;
    }


}
