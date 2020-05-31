using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControls : MonoBehaviour
{
    public void ContinuePressed()
    {
        GameObject obj = GameObject.Find("GameManager");
        SpawnField script = obj.GetComponent<SpawnField>();
        script.Pause();
    }
   
    public void ToMenuPressed()
    {
        GameObject obj = GameObject.Find("GameManager");
        SpawnField script = obj.GetComponent<SpawnField>();
        script.ClearField();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        
    }
   
}
