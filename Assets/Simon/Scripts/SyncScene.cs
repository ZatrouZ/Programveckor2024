using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SyncScene : MonoBehaviour
{
    public static SyncScene instance;

    public bool SyncNow;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
