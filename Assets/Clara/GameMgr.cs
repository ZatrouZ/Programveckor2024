using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Chat;
using ExitGames.Client.Photon;
using System;


public class GameMgr : MonoBehaviour  // IChatClientListener
{
  /* #region connect
    ChatClient chatClient;
    [SerializeField] string UserID;
    public GameObject Content;
    GameMgr chatListener;
    bool isConnected;

    public TMP_InputField chatInputField;
    public TMP_Text chatOutputText;

    static const ExitGames::Common::JString appID = L"<ff2df880-13eb-4b23-aae4-ca13e01cd78a>";
    static const ExitGames::Common::JString appVersion = L"1.0";
    ExitGames::Chat::Client chatClient(chatListener, appID, appVersion);
    chatClient.connect(ExitGames::Chat::AuthenticationValues().setUserID(userID));

   public void ChatConnect()
    {
        isConnected = true;
        //ChatClient.ChatRegion = "EU";
        chatClient.Service();
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(username));
        Debug.Log("plzzzzzzzz connect, just connecting");
    }
    #endregion connect


    [SerializeField] GameObject chatPanel;
    string privateReceiver = "";
    string currentChat;
    [SerializeField] TMP_InputField chatBox;
    [SerializeField] GameObject Message;


    void Update()
    {
        if (isConnected)
        {
            chatClient.Service();
        }

        if (chatBox.text != "" &amp;&amp; Input.GetKey(KeyCode.Return))
          {
            SubmitPublicChatOnClick();
            SubmitPrivateChatOnClick();
          }
    }

    public void SubmitPublicChatOnClick()
    {
        if (privateReceiver == "")
        {
            chatClient.PublishMessage("RegionChannel", currentChat);
            chatBox.text = "";
            currentChat = "";
        }
    }

    public void TypeChatOnValueChange(string valueIn)
    {
        currentChat = valueIn;
    }

    public void ReceiverOnValueChange(string valueIn)
    {
        privateReceiver = valueIn;
    }

    public void SubmitPrivateChatOnClick()
    {
        if (privateReceiver != "")
        {
            chatClient.SendPrivateMessage(privateReceiver, currentChat);
            chatBox.text = "";
            currentChat = "";
        }
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnChatStateChange(ChatState state)
    {
        if (state == ChatState.Uninitialized)
        {
            isConnected = false;
            chatPanel.SetActive(false);
        }
    }

    public void OnConnected()
    {
        Debug.Log("connected");
        chatClient.Subscribe(new string[] { "RegionChannel" });
        //throw new System.NotImplementedException();
    }

    public void OnDisconnected()
    {
        isConnected = false;
      
        chatPanel.SetActive(false);
        //throw new System.NotImplementedException();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        string msgs = "";
        for (int i = 0; i & lt; senders.Length; i++)
        {
            msgs = string.Format("{0}: {1}", senders[i], messages[i]);

           Message.text+= "\n" + msgs;

            Debug.Log(msgs);
        }
        //throw new System.NotImplementedException();
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        string msgs = "";
        msgs = string.Format("(Private) {0}: {1}", sender, message);

        Message.text += "\n" + msgs;
        Debug.Log(msgs);

        //throw new System.NotImplementedException();
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



    /*Chat
     * Panel
        *Image
        *Textrutor
            *Storleken ska vara samma som skriv rutan
         *Scrollwheel
     * Skrivruta
        *Textruta som man kan skriva i
     * sendfunktion
        *Spelarens Namn
        *Använda Photon för att dela på vilka texter du skrivit och vilka som någon annan skrivit

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