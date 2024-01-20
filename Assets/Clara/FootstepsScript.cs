using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootstepsScript : MonoBehaviour
{
        public AudioSource audioSource;
        public AudioClip[] audioClipArray;
        AudioClip lastClip;

    void Start()
    {
        audioSource.PlayOneShot(RandomClip());
    }
    
    AudioClip RandomClip()
    {
        int attempt = 3;
        AudioClip newClip = audioClipArray[Random.Range(0, audioClipArray.Length)];

        while(newClip == lastClip && attempt > 0)
        {
           newClip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            attempt--;
        }
        lastClip = newClip;
        return newClip;
    }
}
