using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class KillScene : MonoBehaviour, IPunObservable
{
    public static KillScene instance;

    public bool SyncNow;

    public bool hasLoaded = false;



    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(SyncNow);
            //stream.SendNext(hasLoaded);
        }
        else if (stream.IsReading)
        {
            SyncNow = (bool)stream.ReceiveNext();
            //hasLoaded = (bool)stream.ReceiveNext();
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

            SceneManager.LoadScene("cutscene i dont know");
            SyncNow = false;

        }
    }


}
