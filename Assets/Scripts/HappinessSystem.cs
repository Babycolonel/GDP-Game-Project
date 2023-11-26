using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;

public class HappinessSystem : MonoBehaviour
{
    public float maxHappiness = 100;
    public float minHappiness = 0;
    public float currentHappiness;

    public TMP_Text percentage; //percentage text
    public BarSetting HB; //class or variable used to call functions from the happiness bar script

    // Start is called before the first frame update
    void Start()
    {
        currentHappiness = maxHappiness;
        HB.SetMaxBar(maxHappiness);
        HB.SetBar(currentHappiness);
        HB.SetMinBar(minHappiness);

        percentage.text = currentHappiness + "%";

        Cat.onAnyCatDeath.AddListener(DeductHappiness);
    }
    
    
    public void AddHappiness(float value) //for happiness bar increases
    {
        currentHappiness += value;

        if (currentHappiness > 100)
        {
            currentHappiness = 100;
        }

        HB.SetBar(currentHappiness);
        percentage.text = currentHappiness + "%";
    }
    public void MinusHappiness(float value) //for happiness bar decreases
    {
        currentHappiness -= value;

        if (currentHappiness < 0)
        {
            currentHappiness = 0;
        }

        HB.SetBar(currentHappiness);
        percentage.text = currentHappiness + "%";
    }

    public void DeductHappiness()
    {
        MinusHappiness(10);
    }
    void Update()
    {
        HB.SetBar(currentHappiness);
        
    }
}
