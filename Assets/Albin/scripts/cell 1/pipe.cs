using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{

    GameObject PipeInHand;
    bool pickup;
    public bool hasPipe;
    // Start is called before the first frame update
    void Start()
    {
        PipeInHand = GameObject.FindWithTag("PipeInHand");
        PipeInHand.SetActive(false);
        pickup = false;
        hasPipe = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickup==true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                hasPipe = true;
                PipeInHand.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickup = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickup = false;
        }
    }
}
