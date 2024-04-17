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
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 4)
        {
            if (PhotonNetwork.IsMasterClient == true)
            {
                PhotonNetwork.LoadLevel("Main Menu(Simon)");
            }
            
            //SceneManager.LoadScene("StartingCells");
            
        }
    }
}
