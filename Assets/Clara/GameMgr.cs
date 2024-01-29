using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Chat;
using ExitGames.Client.Photon;


public class GameMgr : MonoBehaviour, IChatClientListener
{
    ChatClient chatClient;
    [SerializeField] string UserID;

    public TMP_InputField chatBox;
    public GameObject Message;
    public GameObject Content;

    void Start()
    {
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(UserID/*username or whatever we call it*/));
    }

    void Update()
    {
        chatClient.Service();
    }

    /*public void SendMessage()
    {
        GetComponent<PhotonView>().RPC("GetMessage", RpcTarget.All, chatBox.text);

        chatBox.text = "";
    }

    [PunRPC]
    public void GetMessage(string ReceiveMessage)
    {
       GameObject M = Instantiate(Message, Vector3.zero, Quaternion.identity, Content.transform);
       M.GetComponent<chat>().YourMessage.text = ReceiveMessage;
    }*/

    public void DebugReturn(DebugLevel level, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnDisconnected()
    {
        throw new System.NotImplementedException();
    }

    public void OnConnected()
    {
        throw new System.NotImplementedException();
    }

    public void OnChatStateChange(ChatState state)
    {
        throw new System.NotImplementedException();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        throw new System.NotImplementedException();
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnsubscribed(string[] channels)
    {
        throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }


    /*public int maxMessage = 25;

   public GameObject chatPanel, textObject;
    public TMP_InputField chatBox;

    public Color playerMessage, info;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    private void Start()
    {
        
    }

    void Update()
    {
        if(chatBox.text != "")
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }
        else
        {
            if(!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
            }
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToChat("You pressed the space bar", Message.MessageType.info);
                Debug.Log("Space");
            }
        }
          
    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {

        if (messageList.Count >= maxMessage)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
           
        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;

        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
        }

        return color;
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessage,
        info
    }*/
}