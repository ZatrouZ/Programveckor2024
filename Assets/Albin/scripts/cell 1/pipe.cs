using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class pipe : MonoBehaviour
{
    PhotonView View;
    GameObject PipeInHand;
    bool pickup;
    public bool hasPipe;
    PhotonView PlayerView;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartIng());
        View = GetComponent<PhotonView>();
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
        if (pickup==true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (PipeInHand == null)
                {
                    PipeInHand = GameObject.FindWithTag("PipeInHand");
                }
                hasPipe = true;
                View.RPC("RPC1", RpcTarget.All);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickup = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickup = false;
        }
    }

    IEnumerator StartIng()
    {
        yield return new WaitForSeconds(1.5f);
        View.RPC("RPC2", RpcTarget.All);
        pickup = false;
        hasPipe = false;
    }

    [PunRPC]
    void RPC1() 
    {
        PipeInHand.SetActive(true);
        gameObject.SetActive(false);
    }
    [PunRPC]
    void RPC2()
    {
        if (PipeInHand == null)
        {
            PipeInHand = GameObject.FindWithTag("PipeInHand");
        }
        PipeInHand.SetActive(false);
    }
}
