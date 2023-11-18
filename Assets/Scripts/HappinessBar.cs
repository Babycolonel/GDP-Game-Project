using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    public Slider slider; //to access the slider ui

    public void SetMaxHappiness(int happiness) //public methods to be used in the health system script - sets the slider's max value and current value for health bar
    {
        slider.maxValue = happiness;
        //slider.value = happiness;
    }

    public void SetMinHappiness(int happiness) //to set min value of slider instead, lowest health bar can go
    {
        slider.minValue = happiness;
    }

    public void SetHappiness(int happiness) //to set value of slider/current health
    {
        slider.value = happiness;
    }
}

