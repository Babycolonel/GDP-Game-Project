using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; //to access the slider ui

    public void SetMaxHealth(int health) //public methods to be used in the health system script - sets the slider's max value and current value for health bar
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetMinHealth(int health) //to set min value of slider instead, lowest health bar can go
    {
        slider.minValue = health;
    }

    public void SetHealth(int health) //to set value of slider/current health
    {
        slider.value = health;
    }
}
