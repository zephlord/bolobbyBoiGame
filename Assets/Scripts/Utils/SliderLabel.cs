using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderLabel : MonoBehaviour
{
    public Slider slider;
    public Text label;
    public Text value;

    private string key;

    void Awake()
    {
        if(slider == null)
            slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = slider.value.ToString();
    }

    public void setLabel(string labelVal) 
    {
        label.text = labelVal;
        key = labelVal;
    }

}
