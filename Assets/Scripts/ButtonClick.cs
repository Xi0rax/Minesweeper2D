using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    AudioSource fx;
    public AudioClip click;
    public AudioClip hover;

    private void Start()
    {
        fx = GetComponent<AudioSource>();
    }
    public void ClickSound()
    {
        if (Settings.SoundFX == 1)
        fx.PlayOneShot(click, Settings.volume);
    }
  
    public void HoverSound()
    {
        if (Settings.SoundFX == 1)
        fx.PlayOneShot(hover, Settings.volume);
    }

}
