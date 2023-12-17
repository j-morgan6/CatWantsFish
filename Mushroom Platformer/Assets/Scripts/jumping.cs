using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping : MonoBehaviour
{
    private float jumpHeight = 8f;
    private float jumpDistance = 30f;
    private float gravity = 15;

    private CharacterController characterController;
    private playerMovement pm;
    private Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        pm = GetComponent<playerMovement>();
    }

    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        if (characterController.isGrounded)
        {
            velocity.y = -gravity * Time.deltaTime;

            if (Input.GetButtonDown("Jump"))
            {
                // Jump when the jump button is pressed
                velocity.y = Mathf.Sqrt(2 * jumpHeight * gravity);

                // Reset horizontal movement
                velocity.x = 0f;
                velocity.z = 0f;
            }
        }
        else
        {
            // Apply gravity when in the air
            velocity.y -= gravity * Time.deltaTime;
        }

        // Add horizontal movement based on input
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMovement = transform.right * horizontalInput * pm.GetMoveSpeed();

        // Combine the horizontal and forward movement
        velocity.x = horizontalMovement.x;
        velocity.z = horizontalMovement.z; // Use the horizontalMovement directly for z

        // Apply movement
        characterController.Move(velocity * Time.deltaTime);
    }
}
