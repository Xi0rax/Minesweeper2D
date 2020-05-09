using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{

   
    public void startPressed()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);   
    }
    public void settingsPressed()
    {
        Settings.InitSettings();
    }

    public void recordsPressed()
    {
       
    }

    public void exitPressed()
    {
       
        Application.Quit();
    }
}
