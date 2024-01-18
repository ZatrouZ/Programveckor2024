using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doortodocuments : MonoBehaviour
{
    bool reach = false;//bool för om du är inom räckholl för att öppna dörren
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (reach == true)//om du är inom räckholl dör dörren
        {
            if (Input.GetKeyDown(KeyCode.E))//om du klickar E
            {
                SceneManager.LoadScene("Dokument rum");//ladda nästa scen
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//om dörrens hitbox rör spelarens hitbox
        {
            reach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//om spelaren lämnar dörrens hitbox
        {
            reach = false;
        }
    }
}
