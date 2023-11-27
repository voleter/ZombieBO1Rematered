using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DulaimVolume : MonoBehaviour
{
    public Slider sliderVolume;
    public AudioSource BGMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMusicVolume();
    }

    void UpdateMusicVolume()
    {
        BGMusic.volume = sliderVolume.value;
    }
}
