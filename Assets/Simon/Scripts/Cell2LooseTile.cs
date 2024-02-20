using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Cell2LooseTile : MonoBehaviour
{
    [SerializeField]
    public GameObject TileMoved;
    PhotonView View;
    bool pickup;
    public bool hasMovedTile;
    PhotonView PlayerView;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Starting());
        View = GetComponent<PhotonView>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickup == true)
        {
          
                if (Input.GetKey(KeyCode.E) && RealChat.isWriting == false)
                {
                    hasMovedTile = true;
                    View.RPC("RPC1", RpcTarget.All);
                }
            
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            pickup = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            pickup = false;
        }
    }

    IEnumerator Starting() 
    {
        yield return new WaitForSeconds(1.5f);
        View.RPC("RPC2", RpcTarget.All);
        pickup = false;
        hasMovedTile = false;
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerView = player.GetComponent<PhotonView>();
        if (PlayerView.IsMine == true)
        {
            this.enabled = false;
        }
    }

    [PunRPC]
    void RPC1() 
    {
        gameObject.SetActive(false);
        TileMoved.SetActive(true);
    }
    [PunRPC]
    void RPC2()
    {
        TileMoved.SetActive(false);
    }
}
