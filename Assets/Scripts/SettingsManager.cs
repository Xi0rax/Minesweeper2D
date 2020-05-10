using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider MarkersSlider;
    public Slider DiffSlider;
    public Slider VolumeSlider;
    public Toggle SoundToggle;

    void Start()
    {
        MarkersSlider.value = Settings.Markers;
        DiffSlider.value = Settings.difficulty;
        VolumeSlider.value = Settings.remapVolume(Settings.volume, 0, 1, 0, 10);
        SoundToggle.isOn = (Settings.SoundFX == 1) ? true : false;
    }
}
