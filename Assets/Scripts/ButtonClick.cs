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
        fx.PlayOneShot(click);
    }
  
    public void HoverSound()
    {
        fx.PlayOneShot(hover);
    }
}
