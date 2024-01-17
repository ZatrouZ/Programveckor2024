using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Cell2Key : MonoBehaviour
{
    //detta script är en kopia av albins key scripts med några endringar
    Cell2LooseTile LT;
    PhotonView View;
    GameObject File;

    bool reach;
    public bool hasKey;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Starting());
        LT = FindObjectOfType<Cell2LooseTile>();
        View = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LT.hasMovedTile == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                View.RPC("RPC1", RpcTarget.All);
                hasKey = true;
            }
        }
    }
   
    IEnumerator Starting() 
    {
        yield return new WaitForSeconds(1.5f);
        hasKey = false;
        File = GameObject.FindWithTag("File");
        View.RPC("RPC2", RpcTarget.All);
    }

    [PunRPC]
    void RPC1() 
    {
        gameObject.SetActive(false);
        File.SetActive(true);
    }
    [PunRPC]
    void RPC2()
    {
        if (File == null)
        {
            File = GameObject.FindWithTag("File");
        }
        File.SetActive(false);
    }
}
