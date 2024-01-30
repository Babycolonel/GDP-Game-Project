using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HappinessCheck : MonoBehaviour 
{
    public HappinessSystem happinessSystem;
    public GameObject loseScreen, winScreen, dayCount;
    public JoystickMovement playerJoystick;
    public DayCounter dc;

    public void HappyCheck()
    {

        float currentHappiness = happinessSystem.currentHappiness;
        Debug.Log(currentHappiness);
        if (currentHappiness == 0)
        {
            Time.timeScale = 0f;
            Debug.Log("Lose");
            playerJoystick.enabled = false;
            loseScreen.SetActive(true);
        }
        else if (currentHappiness < 100 && currentHappiness >80 && dc.DayNumber == 5)
        {
            Time.timeScale = 0f;
            Debug.Log("Win");
            playerJoystick.enabled = false;
            winScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log("not lose or win");
            dayCount.SetActive(false);
            dc.DayPopUp();
        }
        
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(0);
    }
}