using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
   public void StartGame_Pressed()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Settings_Pressed()
    {
        print(Settings.width.ToString());
    }

    public void Records_Pressed()
    {
        
    }

    public void Exit_Pressed()
    {
        Application.Quit();
    }
}
