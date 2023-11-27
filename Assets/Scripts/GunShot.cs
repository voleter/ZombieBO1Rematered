using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform gunBarrel; // The transform representing the gun's barrel
    public GameObject bulletPrefab; // The bullet prefab to be instantiated when shooting

    public float fireRate = 0.1f; // Rate of fire (bullets per second)

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        nextFireTime = Time.time + 1 / fireRate;
        // Instantiate a bullet or projectile at the gun's barrel position
        Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
        // Implement any additional shooting logic here
    }
}
