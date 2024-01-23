using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    AudioSource AudioSource;

    red red;
    green green;
    yellow yellow;
    blue blue;
    magenta magenta;

    DoorToLastRoom DTLR;

    [SerializeField]
    GameObject panel;
    [SerializeField]
    GameObject Red;
    [SerializeField]
    GameObject Green;
    [SerializeField]
    GameObject Yellow;
    [SerializeField]
    GameObject Blue;
    [SerializeField]
    GameObject Magenta;

    [SerializeField]
    GameObject DTLROBJ;

    bool reach;
    public bool managing;
    public bool open;
    // Start is called before the first frame update
    void Start()
    {
        red = FindObjectOfType<red>();
        green = FindObjectOfType<green>();
        yellow = FindObjectOfType<yellow>();
        blue = FindObjectOfType<blue>();
        magenta = FindObjectOfType<magenta>();
        reach = false;
        managing = false;
        open = false;
        panel.SetActive(false);
        DTLR = DTLROBJ.GetComponent<DoorToLastRoom>();
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Alpha5))
        {
            AudioSource.Play();
        }
        if (reach == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                panel.SetActive(true);
                managing = true;
            }
        }

        if (red.right==true && green.right==true && yellow.right==true && blue.right==true && magenta.right==true)
        {
            panel.SetActive(false);
            open = true;
            DTLR.DoorOpen = true;
            SyncScene.instance.SyncNow = true;
            //svar: grön magenta gul grön röd
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reach = false;
            managing = false;
            panel.SetActive(false);
        }
    }
}
