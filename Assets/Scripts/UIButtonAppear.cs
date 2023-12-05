using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonAppear : MonoBehaviour
{
    private Cat cat;

    [SerializeField] GameObject CatInteractButtons;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cat"))
        {
            CatInteractButtons.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("cat"))
        {
            CatInteractButtons.SetActive(false);
        }
    }
}