using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doortodocuments : MonoBehaviour
{
    bool reach = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (reach == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Dokument rum", LoadSceneMode.Additive);
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
