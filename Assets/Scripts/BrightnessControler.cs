using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    public Light[] lights;
    public Slider brightnessSlider;
    public Text brightnessText;

    private void Start()
    {
        // Add a listener to the Slider's value changed event
        brightnessSlider.onValueChanged.AddListener(ChangeBrightness);
    }

    private void ChangeBrightness(float value)
    {
        // Update the current brightness based on the Slider value
        float brightness = Mathf.Lerp(0.2f, 1.0f, value);

        // Update the lights' intensity
        foreach (Light light in lights)
        {
            light.intensity = brightness;
        }

        // Update the UI Text (optional)
        if (brightnessText != null)
        {
            brightnessText.text = "Brightness: " + brightness.ToString("F2");
        }
    }
}
