using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{

    public int maxMessage = 25;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            SendMessageToChat("You pressed the return button");
        Debug.Log("Return");
    }

    public void SendMessageToChat(string text)
    {

        if (messageList.Count >= maxMessage)
            messageList.Remove(messageList[0]);
            
        Message newMessage = new Message();

        newMessage.text = text;

        messageList.Add(newMessage);
    }
}

[System.Serializable]
public class Message
{
    public string text;
}