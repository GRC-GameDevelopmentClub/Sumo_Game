using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class InGameSetting : MonoBehaviour {
    public AudioSource GameMusic;
    public GameObject PausePanel;
    public GameObject OptionPanel;
    public GameObject PauseButton;
    public GameObject VsyncToggle;
    public GameObject MusicToggle;
    public Slider MusicSlider;
    public MainMenu MainSetting;


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
        MainSetting = new MainMenu();
        QualitySettings.vSyncCount = 0;

    }

    void Start()
    {
        MainSetting.VsyncOff = MainSetting.GetComponent<int>();
        MainSetting.VsyncOn = MainSetting.GetComponent<int>();
        GameMusic = GetComponent<AudioSource>();
        GameMusic.Play();

    }


    void Update()
    {
        GameMusic.volume = MusicSlider.value;


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

    public void VsyncSettingOn()
    {
        if (VsyncToggle.GetComponent<Toggle>().isOn == true)
        {
            VsyncToggle.GetComponent<Toggle>().isOn = true;
            Debug.Log("Turning on VSync...");
            Application.targetFrameRate = MainSetting.VsyncOn;
        }
        else
        {
            VsyncToggle.GetComponent<Toggle>().isOn = false;
            Debug.Log("Turning off VSync...");
            Application.targetFrameRate = MainSetting.VsyncOff;
        }
         
    }

    public void MusicSetting()
    {
        if (MusicToggle.GetComponent<Toggle>().isOn != true)
        {
            Debug.Log("Turning Music Off...");
            MusicSlider.gameObject.SetActive(false);
            AudioListener.volume = MainSetting.MusicVolumeOff;
        }
        else
        {
            Debug.Log("Turning Music On...");
            MusicSlider.gameObject.SetActive(true);
            AudioListener.volume = MainSetting.MusicVolume;
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
