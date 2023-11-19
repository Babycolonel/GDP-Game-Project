using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessCheck : MonoBehaviour
{
    public void Update()
    {
        HappinessSystem happinessSystem = new HappinessSystem();
        int currentHappiness = happinessSystem.currentHappiness;

        if (currentHappiness == 0)
        {
            //Lose();
        }
        else if (currentHappiness == 100)
        {
            //Win();
        }
    }
}
