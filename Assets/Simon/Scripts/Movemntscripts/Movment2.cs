using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movment2 : MonoBehaviour
{
    NoiseManager NoiseManager;
    [SerializeField]
    public float speed = 3;
    Rigidbody2D rb;
    PhotonView View;
    public Animator animator;
    GameObject player;

    [SerializeField]
    GameObject PauseMenuObject;

    private FootstepsScript footstepsScript;
    private bool isWalking;

    public void Awake()
    {
        footstepsScript = GetComponentInChildren<FootstepsScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        View = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RealChat.isWriting == false)
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player2");
            }
            else
            {
                NoiseManager = FindObjectOfType<NoiseManager>();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("interact");
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, speed));
                animator.SetBool("movingUp", true);
                animator.SetFloat("L1R2U3D4", 1);
                animator.SetInteger("facing", 0);
                NoiseManager.totalNoise += Time.deltaTime / 5;
            }
            else
            {
                animator.SetBool("movingUp", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -speed));
                animator.SetBool("movingDown", true);
                animator.SetFloat("L1R2U3D4", 3);
                animator.SetInteger("facing", 3);
                NoiseManager.totalNoise += Time.deltaTime / 5;
            }
            else
            {
                animator.SetBool("movingDown", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(new Vector3(-speed, 0));
                animator.SetBool("movingLeft", true);
                animator.SetFloat("L1R2U3D4", 5);
                animator.SetInteger("facing", 1);
                NoiseManager.totalNoise += Time.deltaTime / 5;
            }
            else
            {
                animator.SetBool("movingLeft", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(new Vector3(speed, 0));
                animator.SetBool("movingRight", true);
                animator.SetFloat("L1R2U3D4", 7);
                animator.SetInteger("facing", 2);
                NoiseManager.totalNoise += Time.deltaTime / 5;
            }
            else
            {
                animator.SetBool("movingRight", false);
            }
        }

        if (isWalking)
        {
            footstepsScript.StartWalking();
        }
        else
        {
            footstepsScript.StopWalking();
        }

    }
}
