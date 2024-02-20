using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desk : MonoBehaviour
{

    NoiseManager NoiseManager;
    [SerializeField]
    GameObject dokument;
    GameObject player;

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
        if (player == null)
        {
            player = GameObject.FindWithTag("Player2");
        }
        else
        {
            NoiseManager = FindObjectOfType<NoiseManager>();
        }
        if (deskSearch==true)
        {
            if (Input.GetKeyDown(KeyCode.E) && RealChat.isWriting == false)
            {
                dokument.SetActive(true);
                NoiseManager.totalNoise += 7;
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
