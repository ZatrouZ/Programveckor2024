using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorForCodeLockRoom : MonoBehaviour
{
    bool open;

    GameObject KeyInHand;
    // Start is called before the first frame update
    void Start()
    {
        KeyInHand = GameObject.FindWithTag("Key");
    }

    // Update is called once per frame
    void Update()
    {
        if (open == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 
                gameObject.SetActive(false);
                KeyInHand.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //&& CL.hasKey == true)
        {
            open = true;
            print("open");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            open = false;
        }
    }
}
