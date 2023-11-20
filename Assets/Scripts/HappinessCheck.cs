using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessCheck : MonoBehaviour 
{
    public HappinessSystem happinessSystem;
    public void HappyCheck()
    {
        
        int currentHappiness = happinessSystem.currentHappiness;
        Debug.Log(currentHappiness);
        if (currentHappiness == 0)
        {
            Debug.Log("Lose");
            //Lose();
        }
        else if (currentHappiness == 100)
        {
            Debug.Log("Win");
            //Win();
        }
        else
        {
            Debug.Log("not lose or win");
        }
    }
}