using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    GameObject hasbomb;
    GameObject hasbomb2;
    bool reach = false;
    bool reach2 = false;
    public bool hasBomb = false;
    public bool hasBomb2 = false;
    void Start()
    {

    }

    void Update()
    {
        if (reach == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasBomb = true;
            }
        }
        if (reach2 == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasBomb2 = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reach = true;
        }
        if (collision.gameObject.tag == "Player2")
        {
            reach2 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reach = false;
        }
        if (collision.gameObject.tag == "Player2")
        {
            reach2 = false;
        }
    }
}
