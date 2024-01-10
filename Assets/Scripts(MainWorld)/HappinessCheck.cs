using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessCheck : MonoBehaviour 
{
    public HappinessSystem happinessSystem;
    public GameObject loseScreen, winScreen;
    public JoystickMovement playerJoystick;
    public void HappyCheck()
    {

        float currentHappiness = happinessSystem.currentHappiness;
        Debug.Log(currentHappiness);
        if (currentHappiness == 0)
        {
            Debug.Log("Lose");
            playerJoystick.enabled = false;
            loseScreen.SetActive(true);;
            //Lose();
        }
        else if (currentHappiness == 100)
        {
            Debug.Log("Win");
            playerJoystick.enabled = false;
            winScreen.SetActive(true);;
            //Win();
        }
        else
        {
            Debug.Log("not lose or win");
        }
    }
}