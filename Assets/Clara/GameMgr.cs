using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{

    public int maxMessage = 25;

   public GameObject chatPanel, textObject;

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
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
           
        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}