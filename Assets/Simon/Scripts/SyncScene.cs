using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SyncScene : MonoBehaviour, IPunObservable
{
    public static SyncScene instance;

    public bool SyncNow;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(SyncNow);
        }
        else if (stream.IsReading)
        {
            SyncNow = (bool)stream.ReceiveNext();
        }
    }

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
        if (SyncNow == true)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }
    }
}
