using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    public Object play;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
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
