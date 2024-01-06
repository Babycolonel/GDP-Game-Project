using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad : MonoBehaviour
{
    public Objects objects;
    private void Start()
    {
        ExecuteOnce(); 

    }
    private bool hasFunctionExecuted = false;

    // Call this method to execute the function only once
    public void ExecuteOnce()
    {
        if (hasFunctionExecuted == false)
        {
            DontDestroyOnLoad(gameObject);
            objects.gameObject.SetActive(true);
            hasFunctionExecuted = true;
        }
        else
        {
            Debug.Log("Function already executed!");
        }
    }
}
