using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy/zombie prefab to spawn.
    public Transform[] spawnPoints; // An array of spawn points.

    private float timer = 0f;
    private float respawnInterval = 30f; // 3 minutes in seconds

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= respawnInterval)
        {
            RespawnEnemies();
            timer = 0f; // Reset the timer for the next respawn cycle.
        }
    }

    private void RespawnEnemies()
    {
        for (int i = 0; i < 10; i++)
        {
            // Randomly select a spawn point from the array.
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instantiate the enemy at the chosen spawn point.
            Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
        }
    }
}
