using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Joystick joystick;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float moveH, moveV;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        moveH = 0;
        moveV = 0;
        joystick.input = Vector2.zero;
        //joystick.SnapY = true;
        //joystick.DeadZone = 5;

    }

    void FixedUpdate()
    {
        moveH = joystick.Horizontal;
        moveV = joystick.Vertical;
        Vector2 moveDir = new Vector2 (moveH, moveV);
        rb.velocity = moveDir * speed;

        if (moveH != 0 || moveV != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if (moveH < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
