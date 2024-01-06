using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeHandler : MonoBehaviour
{
    public Objects objects;
    public bool toggleState = false;



    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event when the script is disabled or destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded:" + scene.name);
        ObjectLoader();
    }

    private void ObjectLoader()
    {
        
        if (toggleState)
        {
            objects.gameObject.SetActive(false);
            Debug.Log("changed scene");
        }
        else
        {
            objects.gameObject.SetActive(true);
            Debug.Log("returned to scene");
        }
        toggleState = !toggleState;
    }
}
