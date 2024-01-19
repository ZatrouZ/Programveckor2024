using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PInstan1 : MonoBehaviour
{
    public float xSpawnCo;
    public float ySpawnCo;
    public GameObject Player1Singel;
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
       
            Instantiate(Player1Singel, new Vector3(xSpawnCo, ySpawnCo, 0), Quaternion.identity);
       
    }
}
