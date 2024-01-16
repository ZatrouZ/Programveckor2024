using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    red red;
    green green;
    yellow yellow;
    blue blue;
    magenta magenta;

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
    }

    // Update is called once per frame
    void Update()
    {
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
            open = true;
            print("wohoo");
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
