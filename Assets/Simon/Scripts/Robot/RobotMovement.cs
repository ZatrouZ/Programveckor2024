using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    GameObject Player;
    RobotMain RobotMain;
    // Start is called before the first frame update
    void Start()
    {
        RobotMain = GetComponent<RobotMain>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
            Player = GameObject.FindWithTag("Player2");
        }

        if (RobotMain.chasePlayer == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position,0);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, RobotMain.EndLocation.transform.position, 0);
        }
    }
}
