using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackChat : MonoBehaviour
{
    GameObject chat;
    // Start is called before the first frame update
    void Start()
    {
        chat = GameObject.FindWithTag("Chat");
        StartCoroutine("blackchat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator blackchat() 
    {
        chat.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        chat.SetActive(true);
    }
}
