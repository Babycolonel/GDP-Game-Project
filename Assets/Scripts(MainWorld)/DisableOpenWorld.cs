using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableOpenWorld : MonoBehaviour
{
    public GameObject openWorldObjects;
    public Rigidbody2D playerRb;
    public JoystickMovement joystick;
    public RectTransform joystickHandle;


    // Start is called before the first frame update
    void Start()
    {
        //openWorldObjects = GameObject.Find("OpenWorldStuff");
    }

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().name) == "OpenWorld")
        {
            joystick.enabled = true;
            //joystick.moveH = 0;
            //joystick.moveV = 0;
            //joystickHandle.transform.position = new Vector2 (0, 0);
            openWorldObjects.SetActive(true);

        }
        else
        {
            joystick.enabled = false;
            //joystick.moveH = 0;
            //joystick.moveV = 0;
            joystickHandle.anchoredPosition = new Vector2 (0, 0);
            //joystickHandle.transform.po
            //playerRb.velocity = new Vector2 (0, 0);
            openWorldObjects.SetActive(false);
        }
    }
}
