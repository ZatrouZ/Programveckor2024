using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doortodocuments : MonoBehaviour
{
    bool reach = false;//bool f�r om du �r inom r�ckholl f�r att �ppna d�rren
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (reach == true)//om du �r inom r�ckholl d�r d�rren
        {
            if (Input.GetKeyDown(KeyCode.E))//om du klickar E
            {
                SceneManager.LoadScene("Dokument rum");//ladda n�sta scen
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//om d�rrens hitbox r�r spelarens hitbox
        {
            reach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//om spelaren l�mnar d�rrens hitbox
        {
            reach = false;
        }
    }
}
