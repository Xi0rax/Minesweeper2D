using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsControls : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider markers;
    public Slider difficulty;
    public Slider volume;
    public Toggle isSound;

   public void applyPressed()
    {
        int Sound = ((isSound.isOn) ? (1) : (0));
        Settings.UpdateSettings((int)difficulty.value, (int)markers.value, Sound, (int)volume.value);
    }

    // Update is called once per frame
    public void cancelPressed()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
