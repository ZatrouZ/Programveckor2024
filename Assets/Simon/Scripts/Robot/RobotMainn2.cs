using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMainn2 : MonoBehaviour
{
    [SerializeField]
    GameObject SpawnLocation;
    [SerializeField]
    public GameObject EndLocation;
    [SerializeField]
    GameObject Robot;
    hidingplace2 hidingplace2;
    NoiseManager NoiseManager;
    public bool chasePlayer = true;
    GameObject HidingObj2;

    float timer;

    public GameObject Player;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player2");
        }
        else
        {
            NoiseManager = Player.GetComponent<NoiseManager>();
        }

        if (HidingObj2 == null)
        {
            HidingObj2 = GameObject.FindWithTag("Hiding2");
        }
        else
        {
            hidingplace2 = HidingObj2.GetComponent<hidingplace2>();
        }

        print(hidingplace2);
        print(HidingObj2);
        if (hidingplace2 != null)
        {
            if (hidingplace2.hiding == true)
            {
                chasePlayer = false;
            }
            else
            {
                chasePlayer = true;
                print("Chase");
            }
        }
       
        
        if (NoiseManager != null)
        {
            if (NoiseManager.spawn == true)
            {
                print("SpawnaMain");
                timer += Time.deltaTime;
                if (timer >= 4)
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
        Instantiate(Robot, SpawnLocation.transform.position, Quaternion.identity);
        NoiseManager.RobotActive = true;
        NoiseManager.spawn = false;
    }

}