using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Instan3 : MonoBehaviour
{
    public float xSpawnCo;
    public float ySpawnCo;

    public GameObject Player1Singel2;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreatePlayer", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreatePlayer()
    {

        PhotonNetwork.Instantiate("Player1Singel2", new Vector3(xSpawnCo, ySpawnCo, 0), Quaternion.identity);

    }
}
