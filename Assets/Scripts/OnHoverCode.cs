using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource sound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Play the sound when the button is hovered
        sound.Play();
    }
}
