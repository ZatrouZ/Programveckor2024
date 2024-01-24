using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
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
            PhotonNetwork.Instantiate("Player1", p1SpawnLoc.position , Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("Player2", p2SpawnLoc.position , Quaternion.identity);
        }
            
    }
}
