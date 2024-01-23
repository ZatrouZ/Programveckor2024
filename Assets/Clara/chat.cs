using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class chat : MonoBehaviour
{

    public TMP_Text YourMessage;


// fel grej igen 
    /*[SerializeField] private GameObject chatUI = null;
    [SerializeField] private TMP_Text chatText = null;
    [SerializeField] private TMP_InputField inputField = null;

    //need so that each player can chat 
    private static event Action<string> OnMessage;

    public override void OnStartAuthority()
    {
        chatUI.SetActive(true);

        OnMessage -= HandleNewMessage; 
    }

    [ClientCallBack]
    private void OnDestroy()
    {
        if (!hasAuthority) { return; }

        OnMessage -= HandleNewMessage;
    }

    //what happens when message happend 
    private void HandleNewMessage(string message)
    {
        chatText.text += message;
    }

    [Client]
    public void send(string message)
    {
        if (!Input.GetKeyDown(KeyCode.Return)) { return; }
        
        if (string.IsNullOrWhiteSpace(message)) { return; }

        CmdSendMessage(inputField.text);

        //clear for next message
        inputField.text = string.Empty;
    }

    [command]
    private void CmdSendMessage(string message)
    {
        //same If we want to validate it here
        RpcHandleMessage($"[{connectionToClient.connectionId}]: {message}");
    }

    [ClientRpc]
    private void RpcHandleMessage(string message)
    {
        //same
        OnMessage?.Invoke($"\n{message}");
    }*/

}
