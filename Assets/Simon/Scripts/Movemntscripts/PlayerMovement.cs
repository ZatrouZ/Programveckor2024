using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    public float speed = 3;
    PhotonView view;
    Rigidbody2D rb;

    public Animator animator;

    [SerializeField]
    GameObject PauseMenuObject;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, speed));
              //  animator.Play("RosaWalkUp");
                animator.SetBool("movingUp", true);
                animator.SetFloat("L1R2U3D4", 1);
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
            }
            else
            {
                animator.SetBool("movingRight", false);
            }
        }

    }
}