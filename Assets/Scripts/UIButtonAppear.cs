using UnityEngine;

public class UIButtonAppear : MonoBehaviour
{
    public Cat cat;
    //public Capture cap;

    [SerializeField] GameObject CatInteractButtons;
    [SerializeField] GameObject CatCaptureButtons;
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
        Debug.Log("Entered trigger zone");
        if (collision.CompareTag("cat"))
        {
            Debug.Log("cat feed on");
            CatInteractButtons.SetActive(true);
            CatCaptureButtons.SetActive(true);
        }
    }
    private void OnCaptureCat()
    {
        // Activate the CatCaptureButtons when a cat is captured
        CatCaptureButtons.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Left trigger zone");
        if (collision.CompareTag("cat"))
        {
            Debug.Log("cat feed off");
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

    }
}