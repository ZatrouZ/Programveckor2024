using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement2 : MonoBehaviour
{

    public AudioSource audioSource;
    GameObject Player;
    GameObject MainObj;
    RobotMainn2 robotMainn2;
    NoiseManager NoiseManager;
    [SerializeField]

    public Animator animator;
    [SerializeField]
    int speed = 4;
    // Start is called before the first frame update
    void Start()
    {
       
        animator = GetComponent<Animator>();
        
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

        if (MainObj == null)
        {
            MainObj = GameObject.FindWithTag("RoboMang");
        }
        else
        {
            robotMainn2 = MainObj.GetComponent<RobotMainn2>();
        }

      
        if (robotMainn2 != null)
        {
            if (robotMainn2.chasePlayer == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
                audioSource.Play();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, robotMainn2.EndLocation.transform.position, speed * Time.deltaTime);
                audioSource.Play();
            }
        }

       
        if (robotMainn2 != null)
        {
            if (Player.transform.position.x < transform.position.x && robotMainn2.chasePlayer == true)
            {
                animator.SetInteger("facing", 1);
            }
            if (Player.transform.position.x > transform.position.x && robotMainn2.chasePlayer == true)
            {
                animator.SetInteger("facing", 2);
            }
            if (Player.transform.position.y < transform.position.y && Player.transform.position.x == transform.position.x || robotMainn2.chasePlayer == false)
            {
                animator.SetInteger("facing", 0);
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

        if (collision.CompareTag("Player2") == true)
        {
            KillScene.instance.SyncNow = true;
        }
    }
}