using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class green_light : MonoBehaviour
{
    control control;
    [SerializeField]
    GameObject green;
    // Start is called before the first frame update
    void Start()
    {
        green.SetActive(false);
        control = GetComponent<control>();
    }

    // Update is called once per frame
    void Update()
    {
        if (control.open==true)
        {
            green.SetActive(true);
        }
    }
}
