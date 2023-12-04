using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatManager : MonoBehaviour
{
    
    public static UnityEvent onFeedingCat = new UnityEvent();
    public static UnityEvent onCaptureCat = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickFeed()
    {
        Feed();
    }

    void Feed()
    {
        onFeedingCat.Invoke();
    }

    public void OnClickCapture()
    {
        Captured();
    }

    void Captured()
    {
        onCaptureCat.Invoke();
    }
}
