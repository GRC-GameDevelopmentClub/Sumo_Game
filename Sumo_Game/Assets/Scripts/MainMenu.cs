using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MainMenu : MonoBehaviour {
    public bool ToogleOn;
    public AudioSource music;
    public Object play;
    public GameObject VsyncToggle;
    public GameObject MusicToggle;
    public Slider MusicSlider;
    public Button PlayButton;
    public float SliderValue;
    public float SliderValueStored;
    public float MusicVolumeOff = 0f;
    public int VsyncOn = 60;
    public int VsyncOff = -1;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        music = GetComponent<AudioSource>();
        music.Play();
    }


    void Update()
    {
        music.volume = MusicSlider.value;
    }

    private void OnEnable()
    {
        PlayButton.onClick.AddListener(MusicOffOnPlay);
    }

   public void MusicOffOnPlay()
   {
        music.Stop();
   }

    public void VsyncSettingOn()
    {
        if (VsyncToggle.GetComponent<Toggle>().isOn == true)
        {
            ToogleOn = true;
            Debug.Log(ToogleOn + " ON BOI");
            Debug.Log("Turning on VSync...");
            Application.targetFrameRate = VsyncOn;
        }
        else
        {
            ToogleOn = false;
            Debug.Log(ToogleOn + " False");
            Debug.Log("Turning off VSync...");
            Application.targetFrameRate = VsyncOff;
        }

    }

    public void MusicSetting()
    {
        if (MusicToggle.GetComponent<Toggle>().isOn != true)
        {
            Debug.Log("Turning Music Off...");
            MusicSlider.gameObject.SetActive(false);
            AudioListener.volume = MusicVolumeOff;
        }
        else
        {
            Debug.Log("Turning Music On...");
            MusicSlider.gameObject.SetActive(true);
            AudioListener.volume = music.volume;
        }
    }

    public void ChangeScene()
    {
        Debug.Log("Loading Scene...");
        SceneManager.LoadScene(play.name);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
