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
                // jump when jump is pressed
                velocity.y = Mathf.Sqrt(2 * jumpHeight * gravity);

                // reset movement
                velocity.x = 0f;
                velocity.z = 0f;
            }
        }
        else
        {
            // gravity while in the air
            velocity.y -= gravity * Time.deltaTime;
        }

        // add horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMovement = transform.right * horizontalInput * pm.GetMoveSpeed();

        // combine the horizontal and forward movement
        velocity.x = horizontalMovement.x;
        velocity.z = horizontalMovement.z;

        // applys movement
        characterController.Move(velocity * Time.deltaTime);
    }
}
