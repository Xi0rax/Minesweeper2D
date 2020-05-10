using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    private void Start()
    {
        Settings.InitSettings();
    }

    public void startPressed()
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);   
    }
    public void settingsPressed()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    public void recordsPressed()
    {
       
    }

    public void exitPressed()
    {
       
        Application.Quit();
    }
}
