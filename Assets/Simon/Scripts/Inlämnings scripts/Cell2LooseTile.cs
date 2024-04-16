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
        View = GetComponent<PhotonView>();//hämtar Photon viewn på objectet scriptet sitter på
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickup == true)
        {
          
                if (Input.GetKey(KeyCode.E) && RealChat.isWriting == false)// om clickar e och inte skriver i chatten
                {
                    hasMovedTile = true;
                    View.RPC("RPC1", RpcTarget.All);//startara RPC för alla
                }
            
            
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            
        }
        else
        {
            PlayerView = player.GetComponent<PhotonView>();//hittar spelarens photonview och om det inte är din stäng av scriptet
        }

        if (PlayerView != null)
        {
            if (PlayerView.IsMine == true)
            {
                this.enabled = false;
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

    IEnumerator Starting() //väntar i 1.5 sekunder eftsrom att spelarna spawnas in 
    {
        yield return new WaitForSeconds(1.5f);
        View.RPC("RPC2", RpcTarget.All);
        pickup = false;
        hasMovedTile = false;
       
       
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
