using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PSWB : MonoBehaviour
{
    public Transform p1SpawnLoc;
    public Transform p2SpawnLoc;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreatePlayer", 0.5f);
    }

    // Update is called once per frame
    void CreatePlayer()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("BombPlayer1", p1SpawnLoc.position, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("BombPlayer2", p2SpawnLoc.position, Quaternion.identity);
        }

    }
}
