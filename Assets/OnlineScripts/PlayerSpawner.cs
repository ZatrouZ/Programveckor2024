using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreatePlayer", 0.5f);
    }

    // Update is called once per frame
    void CreatePlayer()
    {
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            PhotonNetwork.Instantiate("PlayerCar", new Vector3(0, -3.5f, -1), Quaternion.identity);
        }
        else if (PhotonNetwork.PlayerList.Length == 2)
        {
            PhotonNetwork.Instantiate("PlayerCar", new Vector3(3, -3.5f, -1), Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("PlayerCar", new Vector3(-3, -3.5f, -1), Quaternion.identity);
        }
    }
}
