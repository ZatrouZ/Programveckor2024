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
    BoxCollider2D PColider;
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
        else
        {
            movement = player.GetComponent<sINGELmOVMENT>();
            Image = player.GetComponent<SpriteRenderer>();
            PColider = player.GetComponent<BoxCollider2D>();
        }
        if (hiding == true && Input.GetKeyDown(KeyCode.Q))
        {
            hiding = false;
            movement.enabled = true;
            Image.color = new Color(1, 1, 1, 1);
            PColider.enabled = true;
            audioSource.Play();
        }
        else if (reach == true)
        {
            if (Input.GetKeyDown(KeyCode.Q) && RealChat.isWriting == false)
            {
                hiding = true;
                movement.enabled = false;
                Image.color = new Color(1,1,1,0);
                PColider.enabled = false;
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
