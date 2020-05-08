using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
   public void StartGame_Pressed()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void Settings_Pressed()
    {
        Settings.InitSettings();
    }

    public void Records_Pressed()
    {
        
    }

    public void Exit_Pressed()
    {
        Application.Quit();
    }
}
