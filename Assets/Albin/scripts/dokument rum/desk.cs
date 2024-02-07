using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desk : MonoBehaviour
{
    NoiseManager nm;
    [SerializeField]
    GameObject dokument;

    bool deskSearch;
    // Start is called before the first frame update
    void Start()
    {
        nm = FindObjectOfType<NoiseManager>();
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
                nm.totalNoise += 100;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            deskSearch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            dokument.SetActive(false);
            deskSearch = false;
        }
    }
}
