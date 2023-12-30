using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI sliderText;

    [SerializeField] Slider Slider;

    float VolumeValue;
    // Start is called before the first frame update
    void Start()
    {
        sliderText.text = "100";
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = VolumeValue;
    }

    public void SliderChange(float value)
    {
        VolumeValue = value;
        sliderText.text = (VolumeValue*100).ToString("0");
    }
}
