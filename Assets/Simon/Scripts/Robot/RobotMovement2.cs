using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement2 : MonoBehaviour
{
    GameObject Player;
    GameObject MainObj;
    RobotMainn2 RobotMainn2;
    [SerializeField]
    int speed;
    // Start is called before the first frame update
    void Start()
    {
        RobotMainn2 = GetComponent<RobotMainn2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player2");
        }

        if (MainObj == null)
        {
            MainObj = GameObject.FindWithTag("RoboMang");
        }
        else
        {
            RobotMainn2 = MainObj.GetComponent<RobotMainn2>();
        }

        if (RobotMainn2 != null)
        {
            if (RobotMainn2.chasePlayer == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, RobotMainn2.EndLocation.transform.position, speed * Time.deltaTime);
            }
        }
       
    }
}