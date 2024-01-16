using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    key key;

    GameObject KeyInHand;


    bool open;
    // Start is called before the first frame update
    void Start()
    {
        key = FindObjectOfType<key>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open == true)
        {
            KeyInHand = GameObject.FindWithTag("KeyInHand");
            if (Input.GetKey(KeyCode.E))
            {
                KeyInHand.SetActive(false);
                SceneManager.LoadScene("Corridor 1(albin)", LoadSceneMode.Additive);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && key.hasKey == true)
        {
            open = true;
            print("canOpen");
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

