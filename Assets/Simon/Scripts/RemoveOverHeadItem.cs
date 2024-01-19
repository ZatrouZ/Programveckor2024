using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOverHeadItem : MonoBehaviour
{
    GameObject Bomb;

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
    }
}
