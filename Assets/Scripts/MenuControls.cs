using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    private void Start()
    {
        Settings.InitSettings();
        Records.LoadData();
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
        SceneManager.LoadScene("Records", LoadSceneMode.Single);
    }

    public void exitPressed()
    {
       
        Application.Quit();
    }
}
