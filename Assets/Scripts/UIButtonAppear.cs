using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonAppear : MonoBehaviour
{
    [SerializeField] GameObject CatInteractButtons;
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
    }
}