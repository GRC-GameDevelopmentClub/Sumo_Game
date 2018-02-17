using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSetting : MonoBehaviour {
    public GameObject PausePanel;
    public GameObject OptionPanel;
    public GameObject PauseButton;

    //GameObject PauseTag = null;
    //void Start()
    //{
    //    if (GameObject.FindWithTag("pause"))
    //    {
    //        PauseTag = GameObject.FindWithTag("pause");
    //    }
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OptionPanel.activeSelf)
            {
                OptionPanel.SetActive(false);
            }
            if (PausePanel.activeSelf)
            {
                Resume();
                PausePanel.SetActive(false);
            }
            else
            {
                Pause();
            }
        }   
    }

    public void Pause()
    {
        PauseButton.SetActive(false);
        PausePanel.SetActive(true);
        Debug.Log("Pausing Game...");
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PauseButton.SetActive(true);
        Debug.Log("Resuming Game...");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
