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
    [SerializeField] public float timeRemaining;
    public TMP_Text DayCount;
    public bool timerIsRunning = false;
    HappinessCheck happinessCheck = new HappinessCheck();
    private void Start()
    {
        //timeRemaining = 5;
        DayCount.text = "Day: " + DayNumber;
        timerIsRunning = true;
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
                }
                else
                {
                    Debug.Log("Time has run out!");
                    timerIsRunning = false;
                    happinessCheck.HappyCheck();
                }

            }
            //while (DayNumber < 5)
            // {
            //happinessCheck.HappyCheck();
            //}
        }


    }
}