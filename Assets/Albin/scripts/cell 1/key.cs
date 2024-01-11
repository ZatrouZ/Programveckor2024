using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    pipe pipe;

    [SerializeField]
    public GameObject keyInHand;
    [SerializeField]
    GameObject pipeOnGround;

    bool reach;
    public bool hasKey;
    // Start is called before the first frame update
    void Start()
    {
        pipe = FindObjectOfType<pipe>();
        keyInHand.SetActive(false);
        pipeOnGround.SetActive(false);
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (reach==true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                gameObject.SetActive(false);
                pipe.pipeInHand.SetActive(false);
                keyInHand.SetActive(true);
                pipeOnGround.SetActive(true);
                hasKey = true;
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
