using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{
    bool spawnable;
    public float randomN;
    public float noise;
    public float totalNoise;
    float timer;

    private void Update()
    {
        //totalNoise += Time.deltaTime / 5;
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            if (randomN < totalNoise)
            {
                print("spawned");
                totalNoise = 0;
            }
            randomN = Random.Range(50, 500);

            print("fem");
            timer = 0;
            spawner();
        }
    }
    void spawner()
    {
        
    }
}
