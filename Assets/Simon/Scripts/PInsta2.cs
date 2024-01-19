using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PInsta2 : MonoBehaviour
{
   public float xSpawnCo;
    public float ySpawnCo;
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
     
            PhotonNetwork.Instantiate("Player2Singel", new Vector3(xSpawnCo, ySpawnCo, 0), Quaternion.identity);
    

    }
}
