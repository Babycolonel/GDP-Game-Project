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
    public int currentHappinessDisplay;

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
        Cat.onAnyCatDying.AddListener(ReducingHappiness);
        Cat.onAnyCatFeeding.AddListener(AddingHappiness);
        CatManager.onPettingCat.AddListener(PetHappiness);
        CatManager.onPettingTooMuch.AddListener(DeductHappiness);
    }
    
    
    public void AddHappiness(float value) //for happiness bar increases
    {
        currentHappiness += value;

        if (currentHappiness > 100)
        {
            currentHappiness = 100;
        }

        HB.SetBar(currentHappiness);
        percentage.text = currentHappinessDisplay + "%";
    }
    public void MinusHappiness(float value) //for happiness bar decreases
    {
        currentHappiness -= value;

        if (currentHappiness < 0)
        {
            currentHappiness = 0;
        }

        HB.SetBar(currentHappiness);
        percentage.text = currentHappinessDisplay + "%";
    }

    public void DeductHappiness()
    {
        MinusHappiness(10);
    }
    public void ReducingHappiness()
    {
        MinusHappiness(Time.deltaTime);
    }
    public void AddingHappiness()
    {
        AddHappiness(Time.deltaTime/2);
    }
    public void PetHappiness()
    {
        AddHappiness(1);
    }
    void Update()
    {
        HB.SetBar(currentHappiness);
        currentHappinessDisplay = Mathf.RoundToInt(currentHappiness);
    }
}
