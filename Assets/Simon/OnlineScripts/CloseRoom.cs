using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CloseRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
