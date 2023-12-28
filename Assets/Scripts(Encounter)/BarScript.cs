using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public Slider barSlider;
    public Gradient barGradient;
    public Image fill;

    public void SetMaxBar(int health)
    {
        barSlider.maxValue = health;
        barSlider.value = health;

        fill.color = barGradient.Evaluate(1f);
    }

    public void SetBar(int health)
    {
        barSlider.value = health;
        fill.color = barGradient.Evaluate(barSlider.normalizedValue);
    }
}
