using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLabel : MonoBehaviour
{

    public Text value;

    private void Start()
    {
        Slider count = GetComponent<Slider>();
        value.text = count.value.ToString();
    }

     public void setValue()
    {
        Slider count = GetComponent<Slider>();
        value.text = count.value.ToString();
    }
}
