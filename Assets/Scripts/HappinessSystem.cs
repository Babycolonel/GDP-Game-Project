using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessSystem : MonoBehaviour
{
    public int maxHappiness = 100;
    public int minHappiness = 0;
    public int currentHappiness;

    public BarSetting HB; //class or variable used to call functions from the happiness bar script

    // Start is called before the first frame update
    void Start()
    {
        currentHappiness = maxHappiness;
        HB.SetMaxBar(maxHappiness);
        HB.SetBar(currentHappiness);

        HB.SetMinBar(minHappiness);
    }
    
    
    public void AddHappiness(int value) //for happiness bar increases
    {
        currentHappiness += value;

        if (currentHappiness > 100)
        {
            currentHappiness = 100;
        }

        HB.SetBar(currentHappiness);
    }
    public void MinusHappiness(int value) //for happiness bar decreases
    {
        currentHappiness -= value;

        if (currentHappiness < 0)
        {
            currentHappiness = 0;
        }

        HB.SetBar(currentHappiness);
    }

    public void OnHappyUpButton()
    {
        AddHappiness(10);
        Debug.Log(currentHappiness);
    }

    public void OnHappyDownButton()
    {
        MinusHappiness(10);
        Debug.Log(currentHappiness);
    }

    void Update()
    {
        HB.SetBar(currentHappiness);
        
    }
}
