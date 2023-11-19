using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessCheck: MonoBehaviour
{
    public void HappyCheck()
    {
        HappinessSystem happinessSystem = new HappinessSystem();
        int currentHappiness = happinessSystem.currentHappiness;

        if (currentHappiness == 0)
        {
            Debug.Log("Lose eee");
            //Lose();
        }
        else if (currentHappiness == 100)
        {
            Debug.Log("Win");
            //Win();
        }
    }
}
