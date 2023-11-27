using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathSceneUI : MonoBehaviour
{
    public Button playAgainButton;
    public Text roundsSurvivedText;
    public Text moneyCollectedText;
    public Text zombiesKilledText;

    // Set these values from the GameManager or wherever you are tracking the stats
    public int roundsSurvived;
    public int moneyCollected;
    public int zombiesKilled;

    void Start()
    {
        // Attach the PlayAgain function to the button's onClick event
        playAgainButton.onClick.AddListener(PlayAgain);

        // Display the end game statistics
        roundsSurvivedText.text = "Rounds Survived: " + roundsSurvived;
        moneyCollectedText.text = "Money Collected: $" + moneyCollected;
        zombiesKilledText.text = "Zombies Killed: " + zombiesKilled;
    }

    // Function to handle the "Play Again" button click
    private void PlayAgain()
    {
        // Load the main menu scene
        SceneManager.LoadScene("Main");
    }
}
