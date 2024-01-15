using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2Door : MonoBehaviour
{
    Cell2Key Cell2Key;

    [SerializeField]
    GameObject doorOpen;
    bool open;
    // Start is called before the first frame update
    void Start()
    {
       Cell2Key = FindObjectOfType<Cell2Key>();
        doorOpen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (open == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                doorOpen.SetActive(true);
                Cell2Key.keyInHand.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Cell2Key.hasKey == true)
        {
            open = true;
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
