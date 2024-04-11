using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject MainObj;
    public RobotMain RobotMain;
    NoiseManager NoiseManager;
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
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            NoiseManager = player.GetComponent<NoiseManager>();
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
            print("-_-");
            if (RobotMain.chasePlayer == true)
            {
                print("till spelare");
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime );
            }
            else
            {
                print("till slut");
                transform.position = Vector3.MoveTowards(transform.position, RobotMain.EndLocation.transform.position, speed * Time.deltaTime);
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End") == true)
        {
            Destroy(gameObject);
            NoiseManager.RobotActive = false;
        }

        if (collision.CompareTag("Player") == true)
        {
            KillScene.instance.SyncNow = true;
        }
    }

}
