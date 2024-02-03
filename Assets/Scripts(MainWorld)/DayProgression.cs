using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DayProgression : MonoBehaviour
{

    public DayCounter DayCount;
    public GameObject Day1;
    public GameObject Day2;
    public GameObject Day3;
    public GameObject Day4;
    public GameObject Day5;
    public GameObject Vet;
    public GameObject Food;
    public GameObject CatHouse;
    public static UnityEvent onPetReset = new UnityEvent();
    public bool executedD1 = false;
    public bool executedD2 = false;
    public bool executedD3 = false;
    public bool executedD4 = false;
    public bool executedD5 = false;

    void Start()
    {
        Day1.SetActive(false);
        Day2.SetActive(false);
        Day3.SetActive(false);
        Day4.SetActive(false);
        Day5.SetActive(false);
        Vet.SetActive(false);
        Food.SetActive(false);
        //CatHouse.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        if (DayCount.DayNumber == 1) 
        {
            Day1.SetActive(true);
            if (executedD1 == false)
            {
                onPetReset.Invoke();
                executedD1 = true;
            }
        }
        else if (DayCount.DayNumber == 2) 
        { 
            Day2.SetActive(true);
            Day1.SetActive(false);
            Food.SetActive(true);
            if (executedD2 == false)
            {
                onPetReset.Invoke();
                executedD2 = true;
            }
        }
        else if (DayCount.DayNumber == 3) 
        { 
            Day3.SetActive(true);
            Day2.SetActive(false);
            Vet.SetActive(true);
            if (executedD3 == false)
            {
                onPetReset.Invoke();
                executedD3 = true;
            }
        }
        else if (DayCount.DayNumber == 4) 
        { 
            Day4.SetActive(true);
            Day3.SetActive(false);
            //CatHouse.SetActive(true);
            if (executedD4 == false)
            {
                onPetReset.Invoke();
                executedD4 = true;
            }
        }
        else 
        { 
            Day5.SetActive(true);
            Day4.SetActive(false);
            if (executedD5 == false)
            {
                onPetReset.Invoke();
                executedD5 = true;
            }
        }
    }
}
