using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // Reference to the panel in the Inspector

    public void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf); // Toggles the panel's visibility
    }
}
