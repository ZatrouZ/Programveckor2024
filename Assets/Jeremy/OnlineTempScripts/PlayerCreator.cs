using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreatePlayer", 0.5f);

    }

    void CreatePlayer()
    {
        PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity);
    }
   
}
