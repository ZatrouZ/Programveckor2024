using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingplace : MonoBehaviour
{
    public AudioSource audioSource;
    GameObject player;
    sINGELmOVMENT movement;
    SpriteRenderer Image;
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
            movement = player.GetComponent<sINGELmOVMENT>();
            Image = player.GetComponent<SpriteRenderer>();
        }
        if (hiding == true && Input.GetKeyDown(KeyCode.Q))
        {
            hiding = false;
            movement.enabled = true;
            Image.color = new Color(1, 1, 1, 1);
            audioSource.Play();
        }
        else if (reach == true)
        {
            if (Input.GetKeyDown(KeyCode.Q) && RealChat.isWriting == false)
            {
                hiding = true;
                movement.enabled = false;
                Image.color = new Color(1,1,1,0);
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
