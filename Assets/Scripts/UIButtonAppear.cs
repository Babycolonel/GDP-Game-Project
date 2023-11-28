using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class UIButtonAppear : MonoBehaviour
{

    [SerializeField] GameObject CatPrefab1;  // Assumes this prefab contains the cat object
    [SerializeField] GameObject CatInteractButtons;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered trigger zone");

        // Check if the collided object has the "cat" tag
        if (collision.CompareTag("cat"))
        {
            Debug.Log("cat feed on");

            // Set the tag of the collided object to "cat" if it's not already set
            if (!collision.gameObject.CompareTag("cat"))
            {
                collision.gameObject.tag = "cat";
            }

            // Activate the Cat Interact Button UI
            ActivateCatInteractButtonUI();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Left trigger zone");

        // Check if the collided object has the "cat" tag
        if (collision.CompareTag("cat"))
        {
            Debug.Log("cat feed off");

            // Deactivate the Cat Interact Button UI
            DeactivateCatInteractButtonUI();
        }
    }

    private void ActivateCatInteractButtonUI()
    {
        // Instantiate the Cat Interact Buttons if not already instantiated
        if (CatInteractButtons != null)
        {
            Instantiate(CatInteractButtons, transform.position, Quaternion.identity);
        }
    }

    private void DeactivateCatInteractButtonUI()
    {
        // Optionally, you can destroy or deactivate the instantiated Cat Interact Buttons based on your design
        // ...

        // Example: Destroy the instantiated Cat Interact Buttons
        GameObject catInteractButtonsInstance = GameObject.FindGameObjectWithTag("CatInteractButtons");
        if (catInteractButtonsInstance != null)
        {
            Destroy(catInteractButtonsInstance);
        }
    }
    /*[SerializeField] GameObject CatInteractButtons;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered trigger zone");
        if (collision.CompareTag("cat"))
        {
            Debug.Log("cat feed on");
            CatInteractButtons.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Left trigger zone");
        if (collision.CompareTag("cat"))
        {
            Debug.Log("cat feed off");
            CatInteractButtons.SetActive(false);
        }
    }*/
}
