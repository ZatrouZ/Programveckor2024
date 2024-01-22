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
    GameObject CodeLockKey;

    [SerializeField]
    GameObject KEYWITHSCRIPT;

    bool reach;
    public bool hasKey;
    PhotonView PlayerView;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Starting());
        LT = KEYWITHSCRIPT.GetComponent<Cell2LooseTile>();
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

        if (CodeLockKey == null)
        {
            CodeLockKey = GameObject.FindWithTag("LRK");
        }
        else
        {
            CodeLockKey.SetActive(false);
        }

        if (File == null)
        {
            File = GameObject.FindWithTag("File");
        }
    }
   
    IEnumerator Starting() 
    {
        yield return new WaitForSeconds(1.5f);
        hasKey = false;
        View.RPC("RPC2", RpcTarget.All);
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
        File.SetActive(true);
        gameObject.SetActive(false);
    }
    [PunRPC]
    void RPC2()
    {
        File.SetActive(false);
    }
}
