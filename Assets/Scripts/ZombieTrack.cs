using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    private NavMeshAgent agent;

    public int health = 5;
    public int moneyPerHit = 20;

    private int hitsTaken = 0; // New variable to track the number of hits

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target != null)
        {
            // Set the player as the zombie's destination
            agent.SetDestination(target.position);
        }
    }

    // Function to handle when the zombie is hit
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Your code for zombie death goes here

        // Award money to the player
        PlayerController playerController = target.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.AddMoney(moneyPerHit);
        }

        // Destroy the zombie GameObject
        Destroy(gameObject);
    }

    // New function to check if the zombie is dead
    public bool IsDead()
    {
        return hitsTaken >= 5;
    }

    // Modified TakeDamage to increment hitsTaken
    public void TakeDamageAndCheckDeath(int damage)
    {
        hitsTaken++;
        TakeDamage(damage);

        if (IsDead())
        {
            Die();
        }
    }
}
