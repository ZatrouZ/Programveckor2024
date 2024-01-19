using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    [SerializeField]
    GameObject Bomb;
    bool reach = false;
    public bool hasBomb = false;
    public bool boom = false;

    void Start()
    {
        Bomb.SetActive(false);
    }

    void Update()
    {
        if (boom == true)
        {
            Bomb.SetActive(false);
        }
        if (reach == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasBomb = true;
                Bomb.SetActive(true);
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
