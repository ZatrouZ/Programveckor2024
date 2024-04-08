using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMain : MonoBehaviour
{
    [SerializeField]
    GameObject SpawnLocation;
    [SerializeField]
    public GameObject EndLocation;
    [SerializeField]
    GameObject Robot;
    hidingplace hidingplace;
    hidingplace2 hidingplace2;
    NoiseManager NoiseManager;
    public bool chasePlayer;

    float timer;

    public GameObject Player;

    public bool RobotActive;
    // Start is called before the first frame update
    void Start()
    {
        hidingplace = GetComponent<hidingplace>();
        hidingplace2 = GetComponent<hidingplace2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
            //Player = GameObject.FindWithTag("Player2");
        }
        else
        {
            NoiseManager = Player.GetComponent<NoiseManager>();
        }


        /*if (hidingplace.hiding == true || hidingplace2.hiding == true)
        {
            chasePlayer = false;
        }
        */
        if (NoiseManager != null)
        {
            if (NoiseManager.spawn == true)
            {
                print("SpawnaMain");
                timer += Time.deltaTime;
                if (timer <= 5)
                {
                    Spawn();
                    timer = 0;
                }
            }
        }
       
    }
    
    void Spawn() 
    {
        print("instansiate");
        Instantiate(Robot,SpawnLocation.transform.position, Quaternion.identity);
        RobotActive = true;
        NoiseManager.spawn = false;
    }

    void DeSpawn() 
    {
        Destroy(Robot);
        RobotActive = false;
    }
}
