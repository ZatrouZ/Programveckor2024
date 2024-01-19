using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class key : MonoBehaviour
{
    pipe pipe;
    PhotonView View;

    [SerializeField]
    GameObject pipeOnGround;
    [SerializeField]
    GameObject EmptyKeyHook;

    GameObject KeyInHand;

    GameObject PipeInHand;

    bool reach;
    public bool hasKey;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Starting());
        View = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyInHand == null)
        {
            KeyInHand = GameObject.FindWithTag("KeyInHand");
        }

        if (reach==true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                View.RPC("RPC1", RpcTarget.All);
                hasKey = true;
            }
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
        View.RPC("RPC2", RpcTarget.All);
        hasKey = false;
    }

    [PunRPC]
    void RPC1() 
    {
        if (PipeInHand == null)
        {
            PipeInHand = GameObject.FindWithTag("PipeInHand");
        }
        PipeInHand.SetActive(false);
        KeyInHand.SetActive(true);
        pipeOnGround.SetActive(true);
        gameObject.SetActive(false);
        EmptyKeyHook.SetActive(true);
    }
    [PunRPC]
    void RPC2()
    {
        KeyInHand.SetActive(false);
        pipeOnGround.SetActive(false);
    }
}
