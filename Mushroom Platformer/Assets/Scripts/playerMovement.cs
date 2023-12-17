using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class playerMovement : MonoBehaviour
{
    private float moveSpeed = 20f; // Adjust the speed as needed
    private float rotationSpeed = 250f; // Adjust the rotation speed as needed

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        // Get input from the vertical and horizontal axes
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement direction based on the player's forward vector
        Vector3 moveDirection = transform.forward * verticalInput;

        // Calculate the rotation based on the horizontal input
        Vector3 rotation = new Vector3(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(rotation);

        // Normalize the direction to ensure consistent movement speed in all directions
        moveDirection.Normalize();

        // Manually calculate velocity
        Vector3 velocity = moveDirection * moveSpeed;

        // Apply movement using CharacterController
        characterController.SimpleMove(velocity);
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
