using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
        else if (DayCount.DayNumber == 2) 
        { 
            Day2.SetActive(true);
            Day1.SetActive(false);
            Food.SetActive(true);
        }
        else if (DayCount.DayNumber == 3) 
        { 
            Day3.SetActive(true);
            Day2.SetActive(false);
            Vet.SetActive(true);
        }
        else if (DayCount.DayNumber == 4) 
        { 
            Day4.SetActive(true);
            Day3.SetActive(false);
            //CatHouse.SetActive(true);
        }
        else 
        { 
            Day5.SetActive(true);
            Day4.SetActive(false);
        }
    }
}
