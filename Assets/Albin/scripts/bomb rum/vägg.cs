using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vägg : MonoBehaviour
{
    bomb bomb;

    bool reach = false;
    // Start is called before the first frame update
    void Start()
    {
        bomb = FindObjectOfType<bomb>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reach == true)
        {
            if (bomb.hasBomb==true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("wohoo");
                    SceneManager.LoadScene("slut cutscene");
                }
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
}
