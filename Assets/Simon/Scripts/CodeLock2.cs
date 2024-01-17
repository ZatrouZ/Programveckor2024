using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock2 : MonoBehaviour
{
    bool InReach;
    [SerializeField]
    GameObject LockUI;

    bool hasUIUP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (InReach == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LockUI.SetActive(true);
                hasUIUP = true;
            }
        }

        if (hasUIUP == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                LockUI.SetActive(false);
                hasUIUP = false;
            }
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InReach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InReach = false;
        }
    }
}
