using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public RawImage[] photos; // Assign the Raw Image components in the Inspector.
    private int hits = 0;

    void Start()
    {
        HideAllPhotos();
    }

    public void PlayerHitByEnemy()
    {
        if (hits < photos.Length)
        {
            photos[hits].enabled = true; // Enable the next Raw Image to display a new photo.
            hits++;
        }
    }

    void HideAllPhotos()
    {
        foreach (RawImage photo in photos)
        {
            photo.enabled = false; // Initially, hide all Raw Images.
        }
    }
}
