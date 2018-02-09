using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSetting : MonoBehaviour {

    public void Pause()
    {
        Debug.Log("Pausing Game...");
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Debug.Log("Resuming Game...");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
