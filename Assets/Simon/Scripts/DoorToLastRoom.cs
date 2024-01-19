using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class DoorToLastRoom : MonoBehaviour
{
   public bool DoorOpen;
    bool open;
    public bool ConnectedOpen;

    PhotonView View;

    // Start is called before the first frame update
    void Start()
    {
        View = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ConnectedOpen == true)
        {
            View.RPC("OpenLastDoor", RpcTarget.All);
        }

        if (open == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("sista rum(albin)");
                ConnectedOpen = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && DoorOpen == true)
        {
            open = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            open = false;
        }
    }

    [PunRPC]
    void OpenLastDoor() 
    {
        DoorOpen = true;
    }
}
