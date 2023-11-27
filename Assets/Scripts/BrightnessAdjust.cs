using UnityEngine;
using UnityEngine.UI;

public class BrightnessControl : MonoBehaviour
{
    public Slider brightnessSlider;
    public Material material; // The material of the GameObject you want to adjust brightness for

    private float defaultBrightness = 1.0f; // The default brightness value

    private void Start()
    {
        if (material == null || brightnessSlider == null)
        {
            Debug.LogError("Please assign the material and slider in the Inspector.");
            enabled = false; // Disable the script
            return;
        }

        // Initialize the slider value to the default brightness
        brightnessSlider.value = defaultBrightness;

        // Register a callback for the slider's value change
        brightnessSlider.onValueChanged.AddListener(UpdateBrightness);
    }

    // Update the brightness of the material based on the slider value
    private void UpdateBrightness(float value)
    {
        // Ensure the material has a "_Brightness" property in the shader
        if (material.HasProperty("_Brightness"))
        {
            material.SetFloat("_Brightness", value);
        }
    }
}
