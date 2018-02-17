using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSetting : MonoBehaviour {
    public GameObject PausePanel;
    public GameObject OptionPanel;
    public GameObject PauseButton;
    public GameObject VsyncToggle;
    public GameObject MusicToggle;
    public GameObject MusicSlider;
    private int VsynOn = 60;
    //GameObject PauseTag = null;
    //void Start()
    //{
    //    if (GameObject.FindWithTag("pause"))
    //    {
    //        PauseTag = GameObject.FindWithTag("pause");
    //    }
    //}

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
    }


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

        if (MusicToggle.GetComponent<Toggle>().isOn == true)
        {
            MusicSlider.SetActive(true);
        }
    }

    public void VsyncSettingOn()
    {
        Debug.Log("Turning on VSync...");
        Application.targetFrameRate = VsynOn;   
    }

    public void VsyncSettingOff()
    {
        Debug.Log("Turning off VSync...");
        QualitySettings.vSyncCount = 0;
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
