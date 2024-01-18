using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;

public class PlayerScript : MonoBehaviour
{
    public PhotonView pv;
    public Text nameText;

        

    void Start()
    {
        if (pv.IsMine)
        {
            nameText.text = PhotonNetwork.NickName;
        }
        else
        {
            nameText.text = pv.Owner.NickName;
        }


    }

    private void Update()
    {
        

    }


}
