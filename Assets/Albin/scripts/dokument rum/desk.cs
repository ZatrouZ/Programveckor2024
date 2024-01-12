using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desk : MonoBehaviour
{
    [SerializeField]
    GameObject dokument;

    bool deskSearch;
    // Start is called before the first frame update
    void Start()
    {
        dokument.SetActive(false);
        deskSearch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (deskSearch==true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                dokument.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            deskSearch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dokument.SetActive(false);
            deskSearch = false;
        }
    }
}