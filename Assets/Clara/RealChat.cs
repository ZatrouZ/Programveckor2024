using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RealChat : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI chatLog;
    [SerializeField]
    TMP_InputField chatInput;
    List<string> messages = new List<string>();
    PhotonView view;


    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        chatLog.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (messages.Count > 15)
        {
            messages.RemoveAt(0);
        }
    }

    public void InputMessage()
    {
        view.RPC("AddMessage", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber, chatInput.text);
        chatInput.text = "";
    }

    [PunRPC]
    void AddMessage(string playerName, string message)
    {
        messages.Add(playerName + ": " + message);
        chatLog.text += messages[messages.Count - 1] + "\n";
    }
}

