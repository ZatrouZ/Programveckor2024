using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class sINGELmOVMENT : MonoBehaviour
{
    NoiseManager NoiseManager;
    [SerializeField]
    public float speed = 3;
    Rigidbody2D rb;
    PhotonView View;
    AudioSource AudioSource;

    public Animator animator;

    [SerializeField]
    GameObject PauseMenuObject;
    GameObject player;

    public bool walking = false;
    // Start is called before the first frame update
    void Start()
    {
        View = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
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
            NoiseManager = FindObjectOfType<NoiseManager>();
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(0, speed));
            animator.SetBool("movingUp", true);
            animator.SetFloat("L1R2U3D4", 1);
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
            NoiseManager.totalNoise += Time.deltaTime / 5;
        }
        else
        {
            animator.SetBool("movingRight", false);
        }
    }
}
