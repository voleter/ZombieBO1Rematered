using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CombinedController : MonoBehaviour
{
    public Animator animator;
    public AudioSource shootingSound;
    public AudioSource outOfAmmoSound;
    public int maxBullets = 10;
    public int currentBullets;
    public int totalAmmo = 65;
    public int ammoPerReload = 13;
    public float fireRate = 0.2f;
    private float nextFireTime;

    public Text ammoText;
    public GameObject outOfAmmoUI;

    public GameObject cameraGameObject;
    public ParticleSystem flash;
    public GameObject bulletEffectPrefab;
    public Animator gunAnimator;
    private bool RKey = false;
    private float isShooting = 0f;

    void Start()
    {
        currentBullets = maxBullets;
        UpdateAmmoUI();
        outOfAmmoUI.SetActive(false);
    }

    void UpdateAmmoUI()
    {
        ammoText.text = "Ammo: " + currentBullets + " / " + totalAmmo;
        outOfAmmoUI.SetActive(currentBullets == 0 && totalAmmo == 0);
    }

    void Update()
    {
        // Handle input for reloading
        if (Input.GetKeyDown(KeyCode.R))
        {
            RKey = true;
            outOfAmmoSound.Play();
        }

        // Handle input for shooting
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            isShooting = 1f;
        }
        else
        {
            isShooting = 0f;
        }
    }

    void FixedUpdate()
    {
        // If reloading is required, play the reload animation
        if (RKey)
        {
            RKey = false; // Reset the reload trigger
            animator.SetTrigger("Reload");
            Reload();
        }

        // If shooting, play the shooting animation and fire
        if (isShooting > 0)
        {
            animator.SetTrigger("Shoot");
            Fire();
            isShooting = 0f; // Reset isShooting after firing
        }
    }

    void Fire()
    {
        // Play shooting sound
        if (shootingSound != null)
        {
            shootingSound.Play();
        }

        flash.Play();
        RaycastHit hit;

        if (Physics.Raycast(cameraGameObject.transform.position, cameraGameObject.transform.forward, out hit))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * fireRate);
            }

            ZombieController zombie = hit.transform.GetComponent<ZombieController>();
            if (zombie != null)
            {
                // Apply damage to the zombie
                zombie.TakeDamageAndCheckDeath(1); // You can use any positive integer value as the damage here


                // Check if the zombie has reached the maximum damage threshold
                if (zombie.IsDead())
                {
                    KillZombie(zombie);
                }
            }

            CleanUpBulletEffects();

            if (bulletEffectPrefab != null)
            {
                Instantiate(bulletEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }

        currentBullets--;

        if (currentBullets <= 0)
        {
            currentBullets = 0;
        }

        UpdateAmmoUI();
        nextFireTime = Time.time + fireRate;
    }

    void Reload()
    {
        // Play out of ammo sound if there is no ammo left
        if (currentBullets == 0 && totalAmmo == 0 && outOfAmmoSound != null)
        {
            outOfAmmoSound.Play();
        }

        // Calculate how much ammo to add to the current bullets
        int ammoToAdd = Mathf.Min(ammoPerReload, totalAmmo - currentBullets);
        currentBullets += ammoToAdd;
        totalAmmo -= ammoToAdd;

        if (totalAmmo < 0)
        {
            totalAmmo = 0;
        }

        UpdateAmmoUI();
    }

    void KillZombie(ZombieController zombie)
    {
        Destroy(zombie.gameObject);
    }

    void CleanUpBulletEffects()
    {
        GameObject[] bulletEffects = GameObject.FindGameObjectsWithTag("BulletEffect");
        foreach (var bulletEffect in bulletEffects)
        {
            Destroy(bulletEffect);
        }
    }
}