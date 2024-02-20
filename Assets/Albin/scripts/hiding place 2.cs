using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingplace2 : MonoBehaviour
{
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
        }
        if (hiding == true && Input.GetKeyDown(KeyCode.Q))
        {
            hiding = false;
            player2.SetActive(true);
        }
        else if (reach == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hiding = true;
                player2.SetActive(false);
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