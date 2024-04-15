using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    public float speed = 3;
    PhotonView view;
    Rigidbody2D rb;

    public Animator animator;

    private FootstepsScript footstepsScript;

    [SerializeField]
    GameObject PauseMenuObject;
    private bool isWalking;

    public void Awake()
    {
        footstepsScript = GetComponentInChildren<FootstepsScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RealChat.isWriting == false)
        {
            if (view.IsMine)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    rb.AddForce(new Vector3(0, speed));
                    //  animator.Play("RosaWalkUp");
                    animator.SetBool("movingUp", true);
                    animator.SetFloat("L1R2U3D4", 1);
                    animator.SetInteger("facing", 0);
                }
                else
                {
                    animator.SetBool("movingUp", false);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rb.AddForce(new Vector3(0, -speed));
                    //animator.Play("RosaWalkDown");
                    animator.SetBool("movingDown", true);
                    animator.SetFloat("L1R2U3D4", 3);
                }
                else
                {
                    animator.SetBool("movingDown", false);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rb.AddForce(new Vector3(-speed, 0));
                    // animator.Play("RosaWalkLeft");
                    animator.SetBool("movingLeft", true);
                    animator.SetFloat("L1R2U3D4", 5);
                    animator.SetInteger("facing", 1);
                }
                else
                {
                    animator.SetBool("movingLeft", false);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(new Vector3(speed, 0));
                    // animator.Play("RosaWalkRight");
                    animator.SetBool("movingRight", true);
                    animator.SetFloat("L1R2U3D4", 7);
                    animator.SetInteger("facing", 2);
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

}
