using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
    [SerializeField]
    public GameObject pipeInHand;

    bool pickup;
    public bool hasPipe;
    // Start is called before the first frame update
    void Start()
    {
        pipeInHand.SetActive(false);
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
                gameObject.SetActive(false);
                pipeInHand.SetActive(true);
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
