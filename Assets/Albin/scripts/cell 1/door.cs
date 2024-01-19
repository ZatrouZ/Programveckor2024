using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class door : MonoBehaviour
{
    key key;

    GameObject KeyInHand;
    PhotonView View;
    GameObject Player1;

    bool open;
    // Start is called before the first frame update
    void Start()
    {
        key = FindObjectOfType<key>();
        View = GetComponent<PhotonView>();
        PhotonNetwork.AutomaticallySyncScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1 == null)
        {
            Player1 = GameObject.FindWithTag("Player");
        }

        if (open == true)
        {
            KeyInHand = GameObject.FindWithTag("KeyInHand");
            if (Input.GetKey(KeyCode.E))
            {
                View.RPC("RPC1", RpcTarget.All);
                SceneManager.LoadScene("corridor 1(albin)");
                //PhotonNetwork.LoadLevel(5);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && key.hasKey == true)
        {
            open = true;
            print("canOpen");
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
    void RPC1() 
    {
        KeyInHand.SetActive(false);
        Player1.SetActive(false);
    }
}

