using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Cell2Key : MonoBehaviour
{
    //detta script är en kopia av albins key scripts med några endringar
    Cell2LooseTile LT;
    PhotonView View;
    GameObject file;
    GameObject CodeLockKey;

    [SerializeField]
    GameObject KEYWITHSCRIPT;

    bool reach;
    public bool hasKey;
    PhotonView PlayerView;
    GameObject player;
    bool hasActive;

    GameObject groundFile;

    SpriteRenderer FileSprite;
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
        if (View == null)
        {
            View = GetComponent<PhotonView>();
        }

        if (LT.hasMovedTile == true)
        {
                if (Input.GetKey(KeyCode.E))
                {
               // FileSprite.color = new Color(1, 1, 1, 1);
                hasKey = true;
               // gameObject.SetActive(false);
                View.RPC("RPC1", RpcTarget.All);
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

        if (groundFile == null)
        {
            groundFile = GameObject.FindWithTag("GroundFile");
        }
       

        if (file == null)
        {
            file = GameObject.FindWithTag("File");
        }
        else
        {
            FileSprite = file.GetComponent<SpriteRenderer>();
        }

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
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

        if (FileSprite != null && hasActive == false)
        {
            //FileSprite.color = new Color(1, 1, 1, 0);
            View.RPC("RPC2", RpcTarget.All);
            hasActive = true;
        }

        print(file);
    }
   
    IEnumerator Starting() 
    {
        yield return new WaitForSeconds(1.5f);
        hasKey = false;
    }

   [PunRPC]
    void RPC1() 
    {
        FileSprite.color = new Color(1, 1, 1, 1);
        //File.SetActive(true);
        groundFile.SetActive(false);
    }
    [PunRPC]
    void RPC2()
    {
        FileSprite.color = new Color(1, 1, 1, 0);
        //file.SetActive(false);
    }
}
