using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsControls : MonoBehaviour
{
    // Start is called before the first frame update
   public void applyPressed()
    {

    }

    // Update is called once per frame
    public void cancelPressed()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
