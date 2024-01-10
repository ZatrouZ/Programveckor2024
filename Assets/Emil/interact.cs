using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : noisemanager
{
    public bool interacted;
    
    public void OnInterct()
    {
        interacted = true;
        totalNoise += noise;
    }
}
