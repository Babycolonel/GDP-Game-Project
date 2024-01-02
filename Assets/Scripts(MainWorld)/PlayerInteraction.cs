using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInteraction : MonoBehaviour
{
    public Capture Capture;
    public Cat cat;
    //set in the Unity Editor by dragging the respective GameObjects
    public GameObject[] interactableObjects;

    private bool hasInteracted = false;

    public void CheckCapture()
    {
        if ((cat.isCaptured == false) && !hasInteracted)
        {
            GameObject closestObject = FindClosestObject();

            if (closestObject != null)
            {
                InteractWithObject(closestObject);
                hasInteracted = true;
            }
        }
    }

    private GameObject FindClosestObject()
    {
        GameObject closestObject = null;
        float closestDistance = float.MaxValue;
        Vector2 playerPosition = transform.position;

        foreach (GameObject obj in interactableObjects)
        {
            float distance = Vector2.Distance(playerPosition, obj.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj;
            }
        }

        return closestObject;
    }

    private void InteractWithObject(GameObject obj)
    {
        Capture.CaptureCat();
        Debug.Log("Interacting with the closest object: " + obj.name);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (Array.Exists(interactableObjects, obj => obj == other.gameObject))
        {
            // Reset the flag when the player exits the trigger zone
            hasInteracted = false;
        }
    }
}
