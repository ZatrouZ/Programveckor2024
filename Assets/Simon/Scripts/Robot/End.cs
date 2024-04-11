using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    GameObject Robot;
    RobotMovement robotMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Robot == null)
        {
            Robot = GameObject.FindWithTag("Robot");
        }
        else
        {
            robotMovement = Robot.GetComponent<RobotMovement>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Robot")
        {

        }
    }
}
