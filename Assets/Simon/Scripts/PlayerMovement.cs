using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 3;
    PhotonView view;
    Rigidbody2D rb;

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
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -speed));
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(new Vector3(-speed, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(new Vector3(speed, 0));
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Entering Main Menu");
            PauseMenuObject.SetActive(true);

        }
    }
}
