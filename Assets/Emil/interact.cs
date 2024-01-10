using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : noisemanager
{
    public float noise;
    public bool interacted;
    public float totalNoise;
    
    public void OnInterct()
    {
        interacted = true;
        totalNoise += noise;
    }
}
