using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 2.0f; // Mouse sensitivity
    public Transform playerBody; // Reference to the player's body or character controller

    private float rotationX = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Capture mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the camera based on mouse input
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
