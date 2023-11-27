using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // Adjust the speed as needed

    void Start()
    {
        // Get the Rigidbody component of the bullet
        Rigidbody rb = GetComponent<Rigidbody>();

        // Set the velocity of the bullet
        rb.velocity = transform.forward * bulletSpeed;
    }
}
