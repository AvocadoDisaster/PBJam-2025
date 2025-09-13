
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;
    //[SerializeField] private float hoverTimer = 5f;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumping {context.performed} - Is Grounded: {controller.isGrounded}");
        if (context.performed && controller.isGrounded)
        {
            Debug.Log("we are supposed to jump");
            velocity.y = Mathf.Sqrt(jumpHeight + -2f * gravity);
        }
    }

    // public void Hover(InputAction.CallbackContext context)
    //{
    // Debug.Log("we are supposed to hover");
    // if (context)
    //}
    private void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
