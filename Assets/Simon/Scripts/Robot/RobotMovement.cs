using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    GameObject Player;
    GameObject MainObj;
    RobotMain RobotMain;
    [SerializeField]
    int speed;

    public bool destroy;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }

        if (MainObj == null)
        {
            MainObj = GameObject.FindWithTag("RoboMang");
        }
        else
        {
            RobotMain = MainObj.GetComponent<RobotMain>();
        }

        if (RobotMain != null)
        {
            if (RobotMain.chasePlayer == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime );
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, RobotMain.EndLocation.transform.position, speed * Time.deltaTime);
            }
        }

        if (destroy == true)
        {
            Destroy(gameObject);
        }
    }

   
}
