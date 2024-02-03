using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class DayCounter : MonoBehaviour
{
    //initial number of days:
    [SerializeField] public int DayNumber;
    //length of days, in seconds:
    //I changed it so that each day would be equally as long, day length is how long each day is and time remaining is how much more 
    //time left in that day
    [SerializeField] public float dayLength;
    public float timeRemaining;
    public TMP_Text DayCount;
    public TMP_Text DayPop;
    public TMP_Text HappyNumber;
    public bool timerIsRunning = false;
    public HappinessCheck happinessCheck;
    private HappinessSystem happinessSystem;
    public GameObject DayPopScreen, dayCount;
    private void Start()
    {
        happinessSystem = happinessCheck.happinessSystem;
        //timeRemaining = 5;
        DayCount.text = "Day: " + DayNumber;
        DayPop.text = "Day: " + DayNumber;
        HappyNumber.text = "The community happiness is at " + happinessSystem.currentHappiness + "%";
        timerIsRunning = true;
        timeRemaining = dayLength;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                //Counts down the time based on timeRemaining
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if (DayNumber < 5)
                {
                    //increases number of days by 1
                    DayNumber += 1;
                    timeRemaining = 1;
                    DayCount.text = "Day: " + DayNumber;
                    timeRemaining = dayLength;
                    happinessCheck.HappyCheck();
                    DayPopUp();

                }
                else
                {
                    Debug.Log("Time has run out!");
                    timerIsRunning = false;
                    happinessCheck.HappyCheck();
                    Debug.Log(happinessSystem.currentHappiness);
                }

            }
            happinessCheck.HappyCheck();
        }
        //if (DayNumber)
        

    }
    public void DayPopUp()
    {
        dayCount.SetActive(false);
        Time.timeScale = 0;
        DayPopScreen.SetActive(true);
        DayPop.text = "Day: " + DayNumber;
        HappyNumber.text = "The community happiness is at " + happinessSystem.currentHappiness + "%";
    }
    public void OnClickReturnToGame()
    {
        Debug.Log("button working");
        dayCount.SetActive(true);
        DayPopScreen.SetActive(false);
        Time.timeScale = 1;
    }

}