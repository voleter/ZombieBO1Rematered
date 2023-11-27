using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoBrightnessController : MonoBehaviour
{
    public RawImage rawImage;
    public Material brightnessMaterial;

    private void Start()
    {
        rawImage.material = brightnessMaterial;
    }

    public void SetBrightness(float brightness)
    {
        brightnessMaterial.SetFloat("_Brightness", brightness);
    }
}
