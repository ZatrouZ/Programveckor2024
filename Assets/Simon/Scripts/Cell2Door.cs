using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Cell2Door : MonoBehaviour
{
    Cell2Key Cell2Key;

    [SerializeField]
    GameObject BackroundWithHole;
    [SerializeField]
    GameObject BackroundWithoutHole;
    bool open;
    PhotonView View;

    GameObject File;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Starting());
        View = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                View.RPC("RPC2", RpcTarget.All);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Cell2Key.hasKey == true)
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

    IEnumerator Starting() 
    {
        yield return new WaitForSeconds(1.5f);
        Cell2Key = FindObjectOfType<Cell2Key>();
        View.RPC("RPC1", RpcTarget.All);
        File = GameObject.FindWithTag("File");
    }

    [PunRPC]
    void RPC1() 
    {
        BackroundWithHole.SetActive(false);
    }
    [PunRPC]
    void RPC2()
    {
        BackroundWithHole.SetActive(true);
        File.SetActive(false);
        BackroundWithoutHole.SetActive(false);
    }
}
