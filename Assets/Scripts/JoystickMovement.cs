using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Joystick joystick;

    void Start()
    {

    }

    void Update()
    {
        float moveH = joystick.Horizontal;
        float moveV = joystick.Vertical;
        Vector2 moveDir = new Vector2 (moveH, moveV);
        rb.velocity = moveDir * speed;
    }
}
