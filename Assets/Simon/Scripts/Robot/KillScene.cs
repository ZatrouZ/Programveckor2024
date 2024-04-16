using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class KillScene : MonoBehaviour, IPunObservable
{
    public static KillScene instance;
    [SerializeField]
    public bool SyncNow;
    [SerializeField]
    public bool hasLoaded = false;

    float timer;

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
        if (SyncNow == true && hasLoaded == false)
        {

            SceneManager.LoadScene("cutscene i dont know");
            hasLoaded = true;

        }

        if (SyncNow == true&& hasLoaded == true)
        {
            timer += Time.deltaTime;
            if (timer >= 10)
            {
                SyncNow = false;
                hasLoaded = false;
            }
        }

      
    }


}
