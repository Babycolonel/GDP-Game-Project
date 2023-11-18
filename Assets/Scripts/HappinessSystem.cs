using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessSystem : MonoBehaviour
{
    public int maxHappiness = 100;
    public int minHappiness = 0;
    public int currentHappiness;

    public HappinessBar HB; //class or variable used to call functions from the happiness bar script

    // Start is called before the first frame update
    void Start()
    {
        currentHappiness = maxHappiness;
        HB.SetMaxHappiness(maxHappiness);
        HB.SetHappiness(maxHappiness);

        HB.SetMinHappiness(minHappiness);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddHappiness(10);
            Debug.Log("");
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            MinusHappiness(10);
        }

        if (currentHappiness < 0)
        {
            currentHappiness = 0;

        }
        else if (currentHappiness > 100)
        {
            currentHappiness = 100;

        }
    }

    public void HappinessBarStart()
    {
        currentHappiness = maxHappiness;
        HB.SetMaxHappiness(maxHappiness);
        HB.SetHappiness(maxHappiness);

        HB.SetMinHappiness(minHappiness);
    }

    public void HappinessBarUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddHappiness(10);
            Debug.Log("");
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            MinusHappiness(10);
        }

        if (currentHappiness < 0)
        {
            currentHappiness = 0;

        }
        else if (currentHappiness > 100)
        {
            currentHappiness = 100;

        }
    }
    
    

    public void AddHappiness(int happiness) //for happiness bar increases
    {
        currentHappiness += happiness;

        HB.SetHappiness(currentHappiness);
    }
    public void MinusHappiness(int happiness) //for happiness bar decreases
    {
        currentHappiness -= happiness;

        HB.SetHappiness(currentHappiness);
    }
}
