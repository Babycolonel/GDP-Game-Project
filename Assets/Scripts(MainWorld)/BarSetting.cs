using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSetting : MonoBehaviour
{
    public Slider slider; //to access the slider ui

    public void SetMaxBar(float value) //public methods to be used in the health system script - sets the slider's max value and current value for health bar
    {
        slider.maxValue = value;
        //slider.value = happiness;
    }

    public void SetMinBar(float value) //to set min value of slider instead, lowest health bar can go
    {
        slider.minValue = value;
    }

    public void SetBar(float value) //to set value of slider/current health
    {
        slider.value = value;
    }
}
