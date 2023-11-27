using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullCapsuleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sensitivity = 2.0f;
    public float rotationSpeed = 2.0f;
    public float jumpForce = 8f;

    private float verticalRotation = 0;
    private CharacterController characterController;
    private float verticalVelocity;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Rotate();
        LookUpDown();
        Jump();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput));
        moveDirection *= moveSpeed;

        if (characterController.isGrounded)
        {
            verticalVelocity = -1;
            isGrounded = true;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
            isGrounded = false;
        }

        characterController.Move(moveDirection * Time.deltaTime + new Vector3(0, verticalVelocity, 0));
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(Vector3.up * mouseX);
    }

    void LookUpDown()
    {
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        transform.GetChild(0).localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            verticalVelocity = jumpForce;
        }
    }
}
