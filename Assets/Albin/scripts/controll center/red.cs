using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : MonoBehaviour
{
    Renderer rend;

    control control;

    public bool right;
    void Start()
    {
        control = FindObjectOfType<control>();
        rend = GetComponent<Renderer>();
        rend.material.color = Color.red;
        right = false;
    }
    void Update()
    {
        if (control.managing == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
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
