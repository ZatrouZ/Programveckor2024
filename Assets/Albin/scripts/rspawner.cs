using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rspawner : MonoBehaviour
{
    GameObject player;
    public GameObject robot;
    public float xSpawnCo;
    public float ySpawnCo;

    float timer = 3;

    NoiseManager NoiseManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            NoiseManager = player.GetComponent<NoiseManager>();
        }

        if (NoiseManager.spawn == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Instantiate(robot, new Vector3(xSpawnCo, ySpawnCo, 0), Quaternion.identity);
                NoiseManager.spawn = false;
            }
        }   
    }
}
