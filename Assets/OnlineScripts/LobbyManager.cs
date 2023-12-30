using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    int roomSize = 3;

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        print("trying to join");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("cant join a room");
        CreateRoom();
    }

    public void CreateRoom()
    {
        print("creating room");
        int rng = Random.Range(0, 10000000);
        RoomOptions options = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = roomSize, //if not work try (byte) befor variable
        };
        PhotonNetwork.CreateRoom("Room" + rng, options);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
