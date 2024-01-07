using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

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
    public bool timerIsRunning = false;
    public HappinessCheck happinessCheck;
    private HappinessSystem happinessSystem;
    private void Start()
    {
        happinessSystem = happinessCheck.happinessSystem;
        //timeRemaining = 5;
        DayCount.text = "Day: " + DayNumber;
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
                }
                else
                {
                    Debug.Log("Time has run out!");
                    timerIsRunning = false;
                    happinessCheck.HappyCheck();
                    Debug.Log(happinessSystem.currentHappiness);
                }

            }
            //while (DayNumber < 5)
            // {
            //happinessCheck.HappyCheck();
            //}
        }


    }
}