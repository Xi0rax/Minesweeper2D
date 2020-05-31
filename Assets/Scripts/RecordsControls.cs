using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordsControls : MonoBehaviour
{
    
   public void backPressed()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
