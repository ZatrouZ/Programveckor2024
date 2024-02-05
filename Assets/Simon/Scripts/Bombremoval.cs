using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombremoval : MonoBehaviour
{
    GameObject Bomb;
    GameObject Bomb2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Bomb == null)
        {
            Bomb = GameObject.FindWithTag("Bomb");
        }
        else
        {
            Bomb.SetActive(false);
        }
        if (Bomb2 == null)
        {
            Bomb2 = GameObject.FindWithTag("Bomb2");
        }
        else
        {
            Bomb2.SetActive(false);
        }
    }
}
