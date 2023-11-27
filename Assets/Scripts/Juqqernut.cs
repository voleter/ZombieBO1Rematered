using UnityEngine;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    public Text promptText; // Reference to a UI Text element for displaying the prompt.

    private bool canHeal = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger area of the healing object.
        if (other.CompareTag("Player"))
        {
            PlayerHealing playerHealing = other.GetComponent<PlayerHealing>();
            if (playerHealing != null)
            {
                canHeal = true;
                UpdatePromptText();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger area of the healing object.
        if (other.CompareTag("Player"))
        {
            canHeal = false;
            UpdatePromptText();
        }
    }

    void UpdatePromptText()
    {
        if (promptText != null)
        {
            if (canHeal)
            {
                promptText.text = "Press 'H' to heal";
            }
            else
            {
                promptText.text = "";
            }
        }
    }
}
