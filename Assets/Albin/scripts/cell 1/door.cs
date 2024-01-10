using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    key key;

    [SerializeField]
    GameObject doorText;

    bool open;
    // Start is called before the first frame update
    void Start()
    {
        key = FindObjectOfType<key>();
        doorText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (open == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                gameObject.SetActive(false);
                key.keyInHand.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && key.hasKey == true)
        {
            doorText.SetActive(true);
            open = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorText.SetActive(false);
            open = false;
        }
    }
}
