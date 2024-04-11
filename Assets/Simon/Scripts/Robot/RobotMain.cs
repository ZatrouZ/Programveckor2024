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
    HidingPlace2 HidingPlace2;
    GameObject HidingObj;
    NoiseManager NoiseManager;
    public bool chasePlayer;

    float timer;

    public GameObject player;

    
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

        if (HidingObj == null)
        {
            HidingObj = GameObject.FindWithTag("Hiding1");
        }
        else
        {
            HidingPlace2 = HidingObj.GetComponent<HidingPlace2>();
        }
        
        if (HidingPlace2 != null)
        {
            if (HidingPlace2.hiding == true)
            {
                chasePlayer = false;
            }
            else
            {
                chasePlayer = true;
            }
        }
       
        
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
        NoiseManager.RobotActive = true;
        NoiseManager.spawn = false;
    }

  
}
