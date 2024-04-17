using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class DeathReset : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 4)
        {
            if (PhotonNetwork.IsMasterClient == true)
            {
                PhotonNetwork.Disconnect();
                PhotonNetwork.LoadLevel("Main Menu(Simon)");
                //PhotonNetwork.LoadLevel("StartingCells");
            }
            
            //SceneManager.LoadScene("StartingCells");
            
        }
    }
}
