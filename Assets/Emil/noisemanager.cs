using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{
    public float randomN = 200;
    public float noise;
    public float totalNoise;
    float timer;
    public bool spawn = false;

    public bool RobotActive = false;
    private void Start()
    {
        
    }

    private void Update()
    {
       
        if (RobotActive == false)
        {
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                if (randomN < totalNoise)
                {
                    print("spawned");
                    totalNoise = 0;
                    spawn = true;
                }
                randomN = Random.Range(20, 150);
                print("fem");
                timer = 0;
            }
        }
       
    }
}
