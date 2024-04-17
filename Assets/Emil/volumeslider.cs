using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class volumeslider : MonoBehaviour
{
    public string volumeT;
    public TMP_Text volumeText;
    public Slider volumeS;
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        volumeT = volumeS.value.ToString();    
        volume = volumeS.value/100;
        volumeText.text = volumeT;
    }
}
