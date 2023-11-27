using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{
    public Animator animator;
    public AudioSource shootingSound;
    public AudioSource outOfAmmoSound; // Add an AudioSource for out of ammo sound
    public int maxBullets = 10;
    public int currentBullets;
    public int totalAmmo = 65;
    public int ammoPerReload = 13;
    public float fireRate = 0.2f;
    private float nextFireTime;

    public Text ammoText;
    public GameObject outOfAmmoUI;

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
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            if (currentBullets > 0)
            {
                Fire();
                nextFireTime = Time.time + fireRate;
            }
            else
            {
                Reload();
            }
        }
    }

    void Fire()
    {
        // Play shooting animation
        animator.SetTrigger("Shoot");

        // Play shooting sound
        if (shootingSound != null)
        {
            shootingSound.Play();
        }

        // Implement your projectile spawning or shooting logic here
        currentBullets--;

        if (currentBullets <= 0)
        {
            currentBullets = 0;
        }

        UpdateAmmoUI();
    }

    void Reload()
    {
        Debug.Log("Reload method called.");
        // Play reloading animation
        animator.SetTrigger("Reload");

        // Play out of ammo sound if there is no ammo left
        if (currentBullets == 0 && totalAmmo == 0 && outOfAmmoSound != null && Input.GetKeyDown(KeyCode.R))

        {

            outOfAmmoSound.Play();
            Debug.Log("Out of ammo sound played.");
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
}
