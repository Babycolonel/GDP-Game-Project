using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Capture : MonoBehaviour
{
    public Cat cat;
    public PlayerScript player;
    //public Transform catTransform;
    public Transform playerTransform;
    private Vector3 spawnPosition;

    void Start()
    {
        cat = gameObject.GetComponent<Cat>();
    }

    public void CaptureCat()
    {
        
        if ((cat.isPlayer) && (cat.Isdead == false) && (player.hasACapture == false))
        {

            //player.storedCatTransform = catTransform;
            //player.storedCatScript = cat;
            player.storedCat = gameObject;

            gameObject.SetActive(false);

            // cat.isCaptured = true;
            // Debug.Log("captured");

            // float CurrentHunger = cat.CatCurrentHunger;
            // float CurrentHealth = cat.CatCurrentHealth;
            // float[] catValues = { CurrentHunger, CurrentHealth };
            // for (int i = 0; i < catValues.Length; i++)
            // {
            //     Debug.Log(catValues[i]);
            // }
            
            //takes note that player currently has a cat
            player.hasACapture = true;
        }
        
        else if (player.hasACapture == true)
        {
            //RespawnCat();
            player.ReleaseCat();
        }
        
    }

    public void RespawnCat()
    {
        

    }
}
