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
    bool hasActive;

    GameObject RPipe;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartIng());
        View = GetComponent<PhotonView>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (View == null)
        {
            View = GetComponent<PhotonView>();
        }

        if (pickup==true)
        {
            if (Input.GetKey(KeyCode.E) && RealChat.isWriting == false)
            {
                if (PipeInHand == null)
                {
                    PipeInHand = GameObject.FindWithTag("PipeInHand");
                }
                hasPipe = true;
                View.RPC("RPC1", RpcTarget.All);
                //PipeInHand.SetActive(true);
                //gameObject.SetActive(false);
            }
        }

        if (player == null)
        {
            player = GameObject.FindWithTag("Player2");  
        }
        else
        {
            PlayerView = player.GetComponent<PhotonView>();
        }

        if (PlayerView != null)
        {
            if (PlayerView.IsMine == true)
            {
                Destroy(gameObject);
            }
        }

        if (RPipe == null)
        {
            RPipe = GameObject.FindWithTag("RealPipe");
        }

        if (PipeInHand == null)
        {
            PipeInHand = GameObject.FindWithTag("PipeInHand");
        }

        if (PipeInHand != null && hasActive == false)
        {
            //PipeInHand.SetActive(false);
            View.RPC("RPC2", RpcTarget.All);
            hasActive = true;
        }

        print(PipeInHand);
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
      PipeInHand.SetActive(false);
    }
}
