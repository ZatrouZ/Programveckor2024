using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject player;
    public GameObject MainObj;
    public RobotMain RobotMain;
    NoiseManager NoiseManager;
    public Animator animator;
    [SerializeField]
    int speed;

    public bool destroy;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
                audioSource.Play();
            }
            else
            {
                print("till slut");
                transform.position = Vector3.MoveTowards(transform.position, RobotMain.EndLocation.transform.position, speed * Time.deltaTime);
                audioSource.Play();
            }
        }
        if (player.transform.position.x < transform.position.x || RobotMain.chasePlayer == false)
        {
            animator.SetInteger("facing", 1);
            print("vänster");
        }
        if (player.transform.position.x > transform.position.x && RobotMain.chasePlayer == true)
        {
            animator.SetInteger("facing", 2);
            print("höger");
        }
        if (player.transform.position.y < transform.position.y && player.transform.position.x == transform.position.x)
        {
            animator.SetInteger("facing", 0);
            print("up");
        }

        print(NoiseManager);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End") == true)
        {
            print(NoiseManager);
            NoiseManager.RobotActive = false;
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player") == true)
        {
            KillScene.instance.SyncNow = true;
        }
    }

}
