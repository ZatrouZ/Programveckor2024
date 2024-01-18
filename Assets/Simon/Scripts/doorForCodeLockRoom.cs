using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorForCodeLockRoom : MonoBehaviour
{
    bool open;
    CodeLock CL;

    GameObject KeyInHand;
    // Start is called before the first frame update
    void Start()
    {
        KeyInHand = GameObject.FindWithTag("Key");
        CL = GetComponent<CodeLock>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 
                gameObject.SetActive(false);
                KeyInHand.SetActive(false);
                SceneManager.LoadScene("Knapp_pussel(albin)");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && CL.hasKey == true)
        {
            open = true;
            print("open");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            open = false;
        }
    }
}
