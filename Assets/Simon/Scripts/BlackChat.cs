using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackChat : MonoBehaviour
{
    bool yes = true;
    bool no = true;
    GameObject chat;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (yes == true)
        {
            chat = GameObject.FindWithTag("Chat");
            print("find");
        }
        else if (no == true)
        {
            StartCoroutine("blackchat");
            print("start");
            no = false;
        }

        if (chat != null)
        {
            yes = false;
            print("found");
        }
    }

    IEnumerator blackchat() 
    {
        chat.SetActive(false);
        print("false");
        yield return new WaitForSeconds(1.5f);
        chat.SetActive(true);
        print("true");
    }
}
