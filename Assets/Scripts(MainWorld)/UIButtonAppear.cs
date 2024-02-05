using UnityEngine;

public class UIButtonAppear : MonoBehaviour
{
    public Cat cat;
    public Capture cap;

    [SerializeField] GameObject CatInteractButtons;
    [SerializeField] GameObject CatCaptureButtons;
    [SerializeField] GameObject FoodstoreUI;
    [SerializeField] GameObject VetUI;
    [SerializeField] GameObject CatHouseUI;

    public PlayerInfo player;
    private bool isNearCat = false;
    private bool isNearDeadCat = false;

    public Cat catScript;

    public GameObject captureImage, releaseImage;

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cat"))
        {
            //Debug.Log(collision.parent.gameObject.GetComponent<Cat>());
            catScript = collision.transform.parent.gameObject.GetComponent<Cat>();
            CatInteractButtons.SetActive(true);
            if (catScript.Isdead == true)
            {
                isNearDeadCat = true;
            }
            else
            {
                isNearDeadCat = false;
            }
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

        if (collision.CompareTag("CatHouse"))
        {
            CatHouseUI.SetActive(true);
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
            releaseImage.SetActive(false);
            captureImage.SetActive(true);
            
            
            // if (CatManager.onCaptureCat.GetPersistentEventCount() > 0)
            // {
            //     // If there are subscribers, activate the CatCaptureButtons
            //     CatCaptureButtons.SetActive(true);
            // }
            // else
            // {
            //     // If there are no subscribers, do something else or nothing
            //     CatCaptureButtons.SetActive(false);
            // }
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
        if (player.capturedCat == true && isNearCat == false)
        {
            CatCaptureButtons.SetActive(true);
            releaseImage.SetActive(true);
            captureImage.SetActive(false);
        }
        else if (player.capturedCat != true && isNearCat == true)
        {
            if (isNearDeadCat == true)
            {
                CatCaptureButtons.SetActive(false);
                CatInteractButtons.SetActive(false);
            }
            else
            {
                CatCaptureButtons.SetActive(true);
                releaseImage.SetActive(false);
                captureImage.SetActive(true);
            }
            
        }
        else
        {
            CatCaptureButtons.SetActive(false);
        }
    
    }
}