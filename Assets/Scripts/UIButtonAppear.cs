using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonAppear : MonoBehaviour
{
    public Cat cat;
    public Capture cap;

    [SerializeField] GameObject CatInteractButtons;
    [SerializeField] GameObject CatCaptureButtons;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered trigger zone");
        if (collision.CompareTag("cat"))
        {
            Debug.Log("cat feed on");
            CatInteractButtons.SetActive(true);
            CatCaptureButtons.SetActive(true);
            if (cat != null)
            {
                if (cat.isCaptured)
                {
                    CatCaptureButtons.SetActive(false);
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        Debug.Log("Left trigger zone");
        if (collision.CompareTag("cat"))
        {
            Debug.Log("cat feed off");
            CatInteractButtons.SetActive(false);
            CatCaptureButtons.SetActive(false);

        }
        if (cat != null)
        {
            if (cat.isCaptured)
            {
                CatCaptureButtons.SetActive(true);
            }
            else
            {
                CatCaptureButtons.SetActive(false);
            }
        }
        else if (cat.isCaptured)
        {
            CatCaptureButtons.SetActive(true);
        }
    }

}