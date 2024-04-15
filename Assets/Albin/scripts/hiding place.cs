using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingplace : MonoBehaviour
{
    public AudioSource audioSource;
    GameObject player;
    bool reach = false;
    public bool hiding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player==null)
        {
            player = GameObject.FindWithTag("Player");
        }
        if (hiding == true && Input.GetKeyDown(KeyCode.Q))
        {
            hiding = false;
            player.SetActive(true);
            audioSource.Play();
        }
        else if (reach == true)
        {
            if (Input.GetKeyDown(KeyCode.Q) && RealChat.isWriting == false)
            {
                hiding = true;
                player.SetActive(false);
                audioSource.Play();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reach = false;
        }
    }
}
