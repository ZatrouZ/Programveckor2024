using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ServerManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Disconnect();
        startButton.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
        print("Connecting...");
    }

    public override void OnConnectedToMaster()
    {
        startButton.SetActive(true);
        print("I has connected to a sverver in " + PhotonNetwork.CloudRegion);
        PhotonNetwork.AutomaticallySyncScene = true;
    }
}
