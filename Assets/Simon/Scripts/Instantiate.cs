using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Instantiate : MonoBehaviour
{
    public float xP1;
    public float xP2;
    public float yP1;
    public float yP2;

    PhotonView View;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreatePlayer",0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePlayer()
    {
       
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate("Player1", new Vector3(xP1, yP1, 0), Quaternion.identity);
            }
            else
            {
                PhotonNetwork.Instantiate("Player2", new Vector3(xP2, yP2, 0), Quaternion.identity);
            }
        
    }
}
