using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class MovementJoyStick : MonoBehaviour
{
    private InputSystem inputs;
    private Rigidbody2D rb;

    public float speed;
    Animator animator;
    Vector2 moveDir;
    bool isMoving;

    private void Awake()
    {
        inputs = GetComponent<InputSystem>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        moveDir = inputs.moveInput.normalized;
        isMoving = Convert.ToBoolean(moveDir.magnitude);
        animator.SetBool("OnMove", isMoving);
     
    }

    private void FixedUpdate()
    {
        if(rb != null)
        {
            rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
        }
    }
   
}
