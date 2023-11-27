using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 1;
    public GameLogic gameLogic; // Reference to the GameLogic script.

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
            
            // After the player is hit, call the GameLogic script to display a new photo.
            gameLogic.PlayerHitByEnemy();
        }
    }
}
