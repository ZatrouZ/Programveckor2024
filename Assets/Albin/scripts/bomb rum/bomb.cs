using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    GameObject bomb1;
    GameObject bomb2;
    public bool reach = false;
    public bool reach2 = false;
    public bool hasBomb;
    public bool hasBomb2;
    bool hasFoundBomb2 = false;
    bool hasFoundBomb = false;
    void Start()
    {

    }

    void Update()
    {
        if (bomb1 == null)
        {
            bomb1 = GameObject.FindWithTag("Bomb");
            hasFoundBomb = true;
        }
        else if (bomb1 != null && hasFoundBomb == false)
        {
            bomb1.SetActive(false);
            hasFoundBomb = true;
        }

        if (bomb2 == null)
        {
            bomb2 = GameObject.FindWithTag("Bomb2");
        }
        else if (bomb2 != null && hasFoundBomb2 == false)
        {
            bomb2.SetActive(false);
            hasFoundBomb2 = true;
        }


        if (reach == true && hasBomb2 == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasBomb = true;
                bomb1.SetActive(true);
            }
        }
        if (reach2 == true && hasBomb == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasBomb2 = true;
                bomb2.SetActive(true);
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
