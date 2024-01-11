using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    pipe pipe;

    [SerializeField]
    GameObject keyText;
    [SerializeField]
    GameObject keyClueText;
    [SerializeField]
    public GameObject keyInHand;
    [SerializeField]
    GameObject pipeOnGround;

    bool reach;
    public bool hasKey;
    // Start is called before the first frame update
    void Start()
    {
        keyClueText.SetActive(false);
        pipe = FindObjectOfType<pipe>();
        keyText.SetActive(false);
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
            keyText.SetActive(true);
            reach = true;
        }
        else if (collision.gameObject.tag=="Player" && pipe.hasPipe==false)
        {
            keyClueText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            keyText.SetActive(false);
            keyClueText.SetActive(false);
            reach = false;
        }
    }
}
