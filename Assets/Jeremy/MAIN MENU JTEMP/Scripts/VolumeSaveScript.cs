using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSaveScript : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider = null;

    [SerializeField] private Text volumeSliderText = null;


    private void Start()
    {
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        volumeSliderText.text = volume.ToString("0");

    }

    

    public void SaveVolumeButton()
    {
        float VolumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", VolumeValue);
        LoadValues();

    }

    void LoadValues()
    {
        float VolumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = VolumeValue;
        AudioListener.volume = VolumeValue;

    }

}
