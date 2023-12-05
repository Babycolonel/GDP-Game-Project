using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CatData
{
    public string catName;
    public float hunger;
    public float health;

    public CatData(string name, float hungerValue, float healthValue)
    {
        catName = name;
        hunger = hungerValue;
        health = healthValue;
    }
}
public class Capture : MonoBehaviour
{
    public Cat cat;
    private Cat currentCat;
    public Transform playerTransform;

    // List to store captured cat data
    private List<CatData> capturedCats = new List<CatData>();

    void Start()
    {
        cat.isCaptured = false;
        // Assign the playerTransform using the player's tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found in the scene. Assign the playerTransform manually in the Unity Editor.");
        }
    }

    public void CaptureCat()
    {
        currentCat = cat;
        Debug.Log("before check");
        if (currentCat != null && !currentCat.isCaptured && !cat.isCaptured && currentCat.isPlayer && !currentCat.Isdead)
        {
            currentCat.isCaptured = true;
            cat.isCaptured = true;
            Debug.Log("Captured: " + cat.name);

            float currentHunger = currentCat.CatCurrentHunger;
            float currentHealth = currentCat.CatCurrentHealth;

            // Log cat values
            Debug.Log("Current Hunger: " + currentHunger);
            Debug.Log("Current Health: " + currentHealth);

            CatData catData = new CatData(currentCat.name, currentHunger, currentHealth);
            capturedCats.Add(catData);

            StoreCat(catData);

            // Disable the original cat
            currentCat.gameObject.SetActive(false);
        }
        else if (cat != null && currentCat.isCaptured && cat.isCaptured)
        {
            Debug.Log("working");

            RespawnCat(currentCat.CatCurrentHunger, currentCat.CatCurrentHealth);
        }
        Debug.Log("After check");
    }

    private void StoreCat(CatData capturedCatData)
    {
        Debug.Log("Stored cat data - Name: " + capturedCatData.catName + ", Hunger: " + capturedCatData.hunger + ", Health: " + capturedCatData.health);
    }

    public void RespawnCat(float initialHunger, float initialHealth)
    {
        if (cat != null)
        {
            cat.isCaptured = false;
            currentCat.isCaptured = false;
            // Deactivate the original cat
            cat.gameObject.SetActive(false);

            // Move the original cat to the player's position
            cat.transform.position = playerTransform.position;

    
            // Activate the original cat
            cat.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Cat prefab not assigned in the inspector.");
        }
    }
}