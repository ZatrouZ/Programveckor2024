using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{
    public float noise;
    public float totalNoise;
    float timer;

    private void Update()
    {
        totalNoise += Time.deltaTime / 5;
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            print("fem");
            timer = 0;
            spawner();
        }
    }
    void spawner()
    {
        print("spawned");
    }
}
