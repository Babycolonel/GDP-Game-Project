using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//i mostly made this script to keep track if the player is carrying a cat or not, tho maybe can be used to store other info later on 
//aqmount of food or something
public class PlayerScript : MonoBehaviour
{
    public bool hasACapture = false;
    //public Transform storedCatTransform;
    public Cat storedCatScript;
    public GameObject storedCat;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReleaseCat()
    {
        storedCat.transform.position = playerTransform.position + new Vector3(2f, 0f, 0f);
        storedCat.SetActive(true);
        hasACapture = false;
        Debug.Log("Cat released");
    }
}
