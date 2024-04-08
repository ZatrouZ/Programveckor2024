using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootstepsScript : MonoBehaviour
{
    public AudioClip[] footstepSounds;

    public float minTimeBetweenFootsteps = 0.3f;

    public float maxTimeBetweenFootsteps = 0.6f;

    private AudioSource audioSource;

    private bool isWalking = false;

    private float timeSinceLastFootstep;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isWalking)
        {
            if (Time.time - timeSinceLastFootstep >= Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps))
            {
                AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];

                audioSource.PlayOneShot(footstepSound);

                timeSinceLastFootstep = Time.time;
            }
        }
    }

    public void StartWalking()
    {
        isWalking = true;
    }

    public void StopWalking()
    {
        isWalking = false;
    }

    /*public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    AudioClip lastClip;

void Start()
{
    audioSource.PlayOneShot(RandomClip());
}

//spela random
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
}*/
}
