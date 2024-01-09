using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerMovementOnline: MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode forwardWalkKey = KeyCode.W;
    public KeyCode backwardWalkKey = KeyCode.S;
    public KeyCode rightWalkKey = KeyCode.D;
    public KeyCode leftWalkKey = KeyCode.A;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    public Rigidbody rb;

    PhotonView view;


    private void ResetJump()
    {
        readyToJump = true;
    }

    private void Start()
    {
        view = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
        ResetJump();

    }

    private void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKey(KeybindScript1.up))
            {
                forwardWalkKey = KeybindScript1.up;
            }
            else if(Input.GetKey(KeybindScript1.down))
            {
                backwardWalkKey = KeybindScript1.down;
            }
            else if (Input.GetKey(KeybindScript1.right))
            {
                rightWalkKey = KeybindScript1.right;
            }
            else if (Input.GetKey(KeybindScript1.left))
            {
                leftWalkKey = KeybindScript1.left;
            }
            else if (Input.GetKey(KeybindScript1.jump))
            {
                jumpKey = KeybindScript1.jump;
            }


            // ground check
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

            MyInput();
            SpeedControl();

            // handle drag
            if (grounded)
                rb.drag = groundDrag;
            else
                rb.drag = 0;
        }
       
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            MovePlayer();
        }
        
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    
}
