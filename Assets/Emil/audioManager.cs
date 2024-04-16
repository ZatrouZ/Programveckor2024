using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    [SerializeField]
    AudioMixer mixer;
    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("MusicVolume", value);
    }
}
