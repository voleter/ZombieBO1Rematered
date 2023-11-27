using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Text interactText;  // Reference to the UI text displaying interaction prompt
    public int unlockCost = 750;  // Cost to unlock the door

    private Transform player;
    private bool playerInRange = false;

    void Start()
    {
        // Find the player object
        player = GameObject.FindWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player object not found. Make sure to tag your player object with 'Player'.");
        }
    }

    void Update()
    {
        // Check if the player is in range
        playerInRange = Vector3.Distance(transform.position, player.position) < 2f;

        // Display interaction prompt if the player is in range and has enough money
        interactText.text = playerInRange ? "Press F to unlock door ($" + unlockCost + ")" : "";

        // Check for player input to unlock the door
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            TryUnlockDoor();
        }
    }

    void TryUnlockDoor()
    {
        PlayerController playerController = player.GetComponent<PlayerController>();

        if (playerController != null && playerController.HasEnoughMoney(unlockCost))
        {
            // Unlock the door and deduct money
            playerController.DeductMoney(unlockCost);
            OpenDoor();  // Add your door opening logic here
        }
        else
        {
            Debug.Log("Not enough money to unlock the door!");
        }
    }

    void OpenDoor()
    {
        // Implement your door opening logic here
        Debug.Log("Door unlocked! The door is now open.");
        Destroy(gameObject);  // Destroy the door after unlocking (you might want to animate this instead)
    }
}
