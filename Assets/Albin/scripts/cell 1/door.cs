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
    PhotonView PlayerView;
    GameObject player;


    public bool open;
    public bool reach;
    public float timer = .5f;
    // Start is called before the first frame update
    void Start()
    {
        key = FindObjectOfType<key>();
        View = GetComponent<PhotonView>();
        PhotonNetwork.AutomaticallySyncScene = false;
        player = GameObject.FindGameObjectWithTag("Player2");
        PlayerView = player.GetComponent<PhotonView>();
        if (PlayerView.IsMine == true)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (KeyInHand == null)
        {
            KeyInHand = GameObject.FindWithTag("KeyInHand");
        }
        if (reach == true && key.hasKey == true)
        {
            open = true;
            timer -= Time.deltaTime;
        }
        else
        {
            open = false;
        }
        if (open == true && timer < 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                View.RPC("RPC1", RpcTarget.All);
                SceneManager.LoadScene("corridor 1(albin)");
                //PhotonNetwork.LoadLevel(5);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reach = true;
            print("canOpen");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reach = false;
        }
    }

    [PunRPC]
    void RPC1() 
    {
        KeyInHand.SetActive(false);
       
    }
}

