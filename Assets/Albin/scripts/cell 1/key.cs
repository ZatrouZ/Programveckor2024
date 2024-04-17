using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class key : MonoBehaviour
{
    pipe pipe;
    PhotonView View;
    PhotonView PlayerView;

    [SerializeField]
    GameObject pipeOnGround;
    [SerializeField]
    GameObject EmptyKeyHook;

    GameObject player;

    GameObject KeyInHand;

    GameObject PipeInHand;

    bool reach;
    public bool hasKey;
    bool hasActive;

    GameObject RKey;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Starting());
        View = GetComponent<PhotonView>();
        hasActive = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (View == null)
        {
            View = GetComponent<PhotonView>();
        }
        if (KeyInHand == null)
        {
            KeyInHand = GameObject.FindWithTag("KeyInHand");
        }
        if (PipeInHand == null)
        {
            PipeInHand = GameObject.FindWithTag("PipeInHand");
        }

        if (reach==true)
        {
            if (Input.GetKey(KeyCode.E) && RealChat.isWriting == false)
            {
                View.RPC("RPC1", RpcTarget.All);
                /*PipeInHand.SetActive(false);
                KeyInHand.SetActive(true);
                pipeOnGround.SetActive(true);
                gameObject.SetActive(false);
                EmptyKeyHook.SetActive(true);*/
                hasKey = true;
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

        if (RKey == null)
        {
            RKey = GameObject.FindWithTag("RealKey");
        }

        if (PlayerView != null)
        {
            if (PlayerView.IsMine == true)
            {
                Destroy(gameObject);
            }
        }


        if (KeyInHand != null && pipeOnGround != null && hasActive == false)
        {
           // KeyInHand.SetActive(false);
           // pipeOnGround.SetActive(false);
            View.RPC("RPC2", RpcTarget.All);
            hasActive = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && pipe.hasPipe==true)
        {
            reach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reach = false;
        }
    }

    IEnumerator Starting() 
    {
        yield return new WaitForSeconds(1.5f);
        pipe = FindObjectOfType<pipe>();
        hasKey = false;
    }

   [PunRPC]
    void RPC1() 
    {
        PipeInHand.SetActive(false);
        KeyInHand.SetActive(true);
        pipeOnGround.SetActive(true);
        RKey.SetActive(false);
        EmptyKeyHook.SetActive(true);
    }
    [PunRPC]
    void RPC2()
    {
        KeyInHand.SetActive(false);
        pipeOnGround.SetActive(false);
    }
}
