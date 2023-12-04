using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Capture : MonoBehaviour
{
    public Cat cat;
    public void CaptureCat()
    {
        if ((cat.isPlayer) && (cat.Isdead == false))
        {
            cat.isCaptured = true;
            Debug.Log("captured");

            float CurrentHunger = cat.CatCurrentHunger;
            float CurrentHealth = cat.CatCurrentHealth;
            float[] catValues = { CurrentHunger, CurrentHealth };
            for (int i = 0; i < catValues.Length; i++)
            {
                Debug.Log(catValues[i]);
            }



        }
    }

    public void DeleteCat()
    {

    }
}
