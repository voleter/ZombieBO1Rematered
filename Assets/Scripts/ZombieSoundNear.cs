using UnityEngine;

public class AudioController : MonoBehaviour
{
    public GameObject player; // Reference to the player or the object the enemy is near.
    public float triggerDistance = 10f; // The distance at which the audio should start playing.

    private AudioSource audioSource;
    private bool audioIsPlaying = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Check if the enemy is near the player and the audio is not already playing.
        if (distanceToPlayer <= triggerDistance && !audioIsPlaying)
        {
            audioSource.Play();
            audioIsPlaying = true;
        }

        // If the enemy moves away from the player, stop the audio.
        if (distanceToPlayer > triggerDistance && audioIsPlaying)
        {
            audioSource.Stop();
            audioIsPlaying = false;
        }
    }
}
