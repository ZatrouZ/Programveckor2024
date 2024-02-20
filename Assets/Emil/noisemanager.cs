using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{
    rspawner rspawner;
    GameObject player;
    bool spawnable;
    public float randomN;
    public float noise;
    public float totalNoise;
    float timer;
    public bool spawn = false;

    private void Start()
    {
        randomN = 100;
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            rspawner = FindObjectOfType<rspawner>();
        }
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            if (randomN < totalNoise)
            {
                print("spawned");
                totalNoise = 0;
                spawn = true;
            }
            randomN = Random.Range(20, 200);
            print("fem");
            timer = 0;
        }
    }
}
