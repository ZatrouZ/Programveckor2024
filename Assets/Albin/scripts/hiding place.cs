using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingplace : MonoBehaviour
{
    [SerializeField]
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
        if (hiding == true && Input.GetKeyDown(KeyCode.E))
        {
            print("stop hiding");
            hiding = false;
            player.SetActive(true);
        }
        else if (reach == true)
        {
            print("reach");
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("hinding");
                hiding = true;
                player.SetActive(false);
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
