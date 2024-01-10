using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    [SerializeField]
    bool locked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (locked == false)
        {
            if (collision.gameObject.tag == "Interactable" && Input.GetKey(KeyCode.E))
            {

            }
        }
    }
}
