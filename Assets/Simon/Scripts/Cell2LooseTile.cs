using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2LooseTile : MonoBehaviour
{
    [SerializeField]
    public GameObject TileMoved;

    bool pickup;
    public bool hasMovedTile;
    // Start is called before the first frame update
    void Start()
    {
        TileMoved.SetActive(false);
        pickup = false;
        hasMovedTile = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickup == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                hasMovedTile = true;
                gameObject.SetActive(false);
                TileMoved.SetActive(true);
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
