using UnityEngine;
using UnityEngine.UI;

public class PlayerHealing : MonoBehaviour
{
    public RawImage[] healingImages; // Reference to your UI array of healing RawImages
    private int currentIndex = 0;
    private int zombiesKilled = 0;

    void Update()
    {
        // Implement your logic for detecting and counting zombie kills.
        // For example, when a zombie is killed, call the IncrementZombiesKilled() function.

        // Check if the player has killed 10 zombies.
        if (zombiesKilled >= 10)
        {
            // Allow the player to heal when the condition is met.
            if (Input.GetKeyDown(KeyCode.H))
            {
                Heal();
            }
        }
    }

    public void IncrementZombiesKilled()
    {
        zombiesKilled++;
    }

    void Heal()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            ShowCurrentHealingImage();
        }
    }

    void ShowCurrentHealingImage()
    {
        for (int i = 0; i < healingImages.Length; i++)
        {
            if (i == currentIndex)
            {
                healingImages[i].enabled = true;
            }
            else
            {
                healingImages[i].enabled = false;
            }
        }
    }
}
