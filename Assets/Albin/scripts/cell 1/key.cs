using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    pipe pipe;

    [SerializeField]
    GameObject pipeOnGround;

    GameObject KeyInHand;

    GameObject PipeInHand;

    bool reach;
    public bool hasKey;
    // Start is called before the first frame update
    void Start()
    {
        pipe = FindObjectOfType<pipe>();
        KeyInHand = GameObject.FindWithTag("KeyInHand");
        
        KeyInHand.SetActive(false);
        pipeOnGround.SetActive(false);
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (reach==true)
        {
            PipeInHand = GameObject.FindWithTag("PipeInHand");
            if (Input.GetKey(KeyCode.E))
            {
                PipeInHand.SetActive(false);
                KeyInHand.SetActive(true);
                pipeOnGround.SetActive(true);
                hasKey = true;
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && pipe.hasPipe==true)
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
