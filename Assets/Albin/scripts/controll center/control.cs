using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
    //Albin
{
    NoiseManager NoiseManager;
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

    GameObject player;

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
        if (player == null) //om spelaren inte finns 
        {
            player = GameObject.FindWithTag("Player");//hitta efter spelaren
        }
        else
        {
            NoiseManager = FindObjectOfType<NoiseManager>();//hitta noisemanager scriptet 
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            AudioSource.Play();//spelar ljud av att trycka på knappar
            NoiseManager.totalNoise += 4;//ökar ljudnivån
        }
        if (reach == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && RealChat.isWriting == false)
            {
                panel.SetActive(true);
                managing = true;
                NoiseManager.totalNoise += 7;
            }
        }

        if (red.right==true && green.right==true && yellow.right==true && blue.right==true && magenta.right==true)
        {
            panel.SetActive(false);
            open = true;
            DTLR.DoorOpen = true;
          
            //svar: grön magenta gul grön röd
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//om spelaren är inom räckhåll
    {
        if (collision.gameObject.tag == "Player")
        {
            reach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//om spelaren inte är inom räckhåll
    {
        if (collision.gameObject.tag == "Player")
        {
            reach = false;
            managing = false;
            panel.SetActive(false);//ta bort hudden
        }
    }
}
