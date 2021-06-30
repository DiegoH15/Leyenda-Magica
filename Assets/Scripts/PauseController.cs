using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    bool isPaused = false;
    public GameObject PausePanel;
    public static PauseController instance;

    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            PausePanel.SetActive(false);
            isPaused = false;
        }
        else
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}
