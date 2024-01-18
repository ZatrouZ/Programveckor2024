using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vägg : MonoBehaviour
{
    [SerializeField]
    GameObject wall;
    [SerializeField]
    GameObject brokenwall;

    bool reach = false;
    // Start is called before the first frame update
    void Start()
    {
        brokenwall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (reach == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
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
        }
    }
    void explosion()
    {
        wall.SetActive(false);
        brokenwall.SetActive(true);
    }
}
