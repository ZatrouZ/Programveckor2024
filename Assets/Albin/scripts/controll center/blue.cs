using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blue : MonoBehaviour
{
    //Alla f�rgscripts �r gjorda p� samma s�tt av Albin
    Renderer rend;

    control control;

    public bool right;
    // Start is called before the first frame update
    void Start()
    {
        control = FindObjectOfType<control>();
        rend = GetComponent<Renderer>();
        rend.material.color = Color.blue;//g�r knappen bl�
        right = false;//bool f�r n�r knappen �r r�tt f�rg
    }

    // Update is called once per frame
    void Update()
    {
        if (control.managing == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (rend.material.color == Color.red)
                {
                    rend.material.color = Color.green;
                    right = true;
                }
                else if (rend.material.color == Color.green)
                {
                    rend.material.color = Color.yellow;
                    right = false;
                }
                else if (rend.material.color == Color.yellow)
                {
                    rend.material.color = Color.blue;
                }
                else if (rend.material.color == Color.blue)
                {
                    rend.material.color = Color.magenta;
                }
                else if (rend.material.color == Color.magenta)
                {
                    rend.material.color = Color.red;
                }
            }
        }
    }
}
