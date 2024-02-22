using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SlutSlutScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit_() 
    {
        Application.Quit();
    }

    public void Restart() 
    {
        PhotonNetwork.LoadLevel("PreGameLobby");
    }
}
