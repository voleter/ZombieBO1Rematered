using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            
            LoadNextScene(); // Load the next scene when the player dies
        }
    }

   
    

    void LoadNextScene()
    {
        // Load the next scene here (replace "NextSceneName" with the actual name of the next scene).
        SceneManager.LoadScene("Died");
    }
}
