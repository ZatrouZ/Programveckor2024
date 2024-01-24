using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
     public float p1x = -4;
    public float p1y = -1.15f;
    public float p2x = 5.5f;
    public float p2y = -1.15f;
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
            PhotonNetwork.Instantiate("Player1", new Vector3(-4, -1.15f, 0), Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("Player2", new Vector3(5.5f, -1.15f, 0), Quaternion.identity);
        }
            
    }
}
