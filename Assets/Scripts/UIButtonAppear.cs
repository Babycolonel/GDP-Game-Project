using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonAppear : MonoBehaviour
{
    private Cat cat;
    public PlayerScript player;

    [SerializeField] GameObject CatInteractButtons;
    //i am making the capture button appear separately as the capture button has to remain active while the player is "holding" a cat,
    //unlike the feeding button
    [SerializeField] GameObject CaptureButton;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered trigger zone");
        if (collision.CompareTag("cat"))
        {
            Debug.Log("cat feed on");
            CatInteractButtons.SetActive(true);
            CaptureButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Left trigger zone");
        if (collision.CompareTag("cat"))
        {
            Debug.Log("cat feed off");
            CatInteractButtons.SetActive(false);
            if (player.hasACapture == true)
            {
                CaptureButton.SetActive(false);
            }
            
        }
    }
}