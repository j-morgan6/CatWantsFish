using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class playerMovement : MonoBehaviour
{
    private float moveSpeed = 20f;
    private float rotationSpeed = 150f;

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
        // get input from vert and hor axis
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // calc movement based on forward vector
        Vector3 moveDirection = transform.forward * verticalInput;

        // calc rotation based on rotation input
        Vector3 rotation = new Vector3(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(rotation);

        // normalize the direction
        moveDirection.Normalize();

        // calc velocity
        Vector3 velocity = moveDirection * moveSpeed;

        // use character controller to apply movement
        characterController.SimpleMove(velocity);
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
