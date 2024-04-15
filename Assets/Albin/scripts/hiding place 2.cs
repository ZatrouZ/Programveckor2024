using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingplace2 : MonoBehaviour
{
    Movment2 movment2;
    SpriteRenderer Image;
    GameObject player2;
    bool reach = false;
    public bool hiding = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player2 == null)
        {
            player2 = GameObject.FindWithTag("Player2");
            movment2 = player2.GetComponent<Movment2>();
            Image = player2.GetComponent<SpriteRenderer>();
        }
        if (hiding == true && Input.GetKeyDown(KeyCode.Q))
        {
            hiding = false;
            movment2.enabled = true;
            Image.color = new Color(1, 1, 1, 1);
        }
        else if (reach == true)
        {
            if (Input.GetKeyDown(KeyCode.Q) && RealChat.isWriting == false)
            {
                hiding = true;
                movment2.enabled = false;
                Image.color = new Color(1, 1, 1, 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            reach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            reach = false;
        }
    }
}
