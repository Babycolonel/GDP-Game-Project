using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class DayCounter: MonoBehaviour
{
    [SerializeField]public int DayNumber;
    [SerializeField] public float timeRemaining;
    public TMP_Text DayCount;
    public bool timerIsRunning = false;

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
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if(DayNumber < 5)
                {
                    DayNumber += 1;
                    timeRemaining = 5;
                    DayCount.text = "Day: " + DayNumber;
                }
                else
                {
                    Debug.Log("Time has run out!");
                }
                
            }
        }
        
    }
}
