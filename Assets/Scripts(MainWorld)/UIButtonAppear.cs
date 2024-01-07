using UnityEngine;

public class UIButtonAppear : MonoBehaviour
{
    public Cat cat;
    //public Capture cap;

    [SerializeField] GameObject CatInteractButtons;
    [SerializeField] GameObject CatCaptureButtons;
    [SerializeField] GameObject FoodstoreUI;
    [SerializeField] GameObject VetUI;

    public PlayerInfo player;
    private bool isNearCat = false;

    private void Start()
    {
        // Subscribe to the cat capture event
        CatManager.onCaptureCat.AddListener(OnCaptureCat);
    }

    private void OnDisable()
    {
        // Unsubscribe from the cat capture event to prevent memory leaks
        CatManager.onCaptureCat.RemoveListener(OnCaptureCat);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cat"))
        {
            CatInteractButtons.SetActive(true);
            //CatCaptureButtons.SetActive(true);

            isNearCat = true;
        }
        if (collision.CompareTag("cat") && cat.isCaptured == true)
        {
            CatCaptureButtons.SetActive(false);
        }
        else if (collision.CompareTag("cat"))
        {
            CatCaptureButtons.SetActive(true);
        }

        if (collision.CompareTag("foodstore"))
        {
            FoodstoreUI.SetActive(true);
        }

        if (collision.CompareTag("vet"))
        {
            VetUI.SetActive(true);
        }
    }
    private void OnCaptureCat()
    {
        // Activate the CatCaptureButtons when a cat is captured
        CatCaptureButtons.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isNearCat = false;
        if (collision.CompareTag("cat"))
        {
            CatInteractButtons.SetActive(false);
            
            if (CatManager.onCaptureCat.GetPersistentEventCount() > 0)
            {
                // If there are subscribers, activate the CatCaptureButtons
                CatCaptureButtons.SetActive(true);
            }
            else
            {
                // If there are no subscribers, do something else or nothing
                CatCaptureButtons.SetActive(false);
            }
        }

        if (collision.CompareTag("foodstore"))
        {
            FoodstoreUI.SetActive(false);
        }

        if (collision.CompareTag("vet"))
        {
            VetUI.SetActive(false);
        }
    }

    void Update()
    {
        if (cat.isCaptured == true && isNearCat == false)
        {
            CatCaptureButtons.SetActive(true);
        }
    }
}