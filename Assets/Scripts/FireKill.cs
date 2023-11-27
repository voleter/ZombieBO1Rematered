using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float fireRate = 20f;
    public float force = 80;
    public GameObject cameraGameObject;
    public ParticleSystem flash;
    public GameObject bulletEffectPrefab;
    public Animator gunAnimator;

    private bool noBullets = false;
    private bool RKey = false;
    private float isShooting = 0f;

    private void Update()
    {
        // Handle input for reloading
        if (Input.GetKeyDown(KeyCode.R))
        {
            RKey = true;
        }

        // Handle input for shooting
        if (Input.GetButton("Fire1"))
        {
            isShooting = 1f;
        }
        else
        {
            isShooting = 0f;
        }
    }

    private void FixedUpdate()
    {
        // If reloading is required, play the reload animation
        if (RKey)
        {
            RKey = false; // Reset the reload trigger
            gunAnimator.SetTrigger("Reload");
            Reload();
        }

        // If shooting, play the shooting animation and fire
        if (isShooting > 0)
        {
            gunAnimator.SetTrigger("Shoot");
            Debug.Log("Shoot Trigger Set"); // Add this line for debugging
            Fire();
            isShooting = 0f; // Reset isShooting after firing
        }
    }

    private void Fire()
    {
        flash.Play();
        RaycastHit hit;

        if (Physics.Raycast(cameraGameObject.transform.position, cameraGameObject.transform.forward, out hit))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }

            ZombieController zombie = hit.transform.GetComponent<ZombieController>();
            if (zombie != null)
            {
                KillZombie(zombie);
            }

            CleanUpBulletEffects();

            if (bulletEffectPrefab != null)
            {
                Instantiate(bulletEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

    private void KillZombie(ZombieController zombie)
    {
        Destroy(zombie.gameObject);
    }

    private void Reload()
    {
        // Your reloading logic here
        // For example, update noBullets and handle reloading animation
        noBullets = false; // Reset noBullets
        // Your reloading logic here, e.g., increase bullet count
    }

    private void CleanUpBulletEffects()
    {
        GameObject[] bulletEffects = GameObject.FindGameObjectsWithTag("BulletEffect");
        foreach (var bulletEffect in bulletEffects)
        {
            Destroy(bulletEffect);
        }
    }
}
