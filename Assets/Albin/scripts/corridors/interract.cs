using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interract : MonoBehaviour
{
    protected bool reach = false;//bool f�r om du �r inom r�ckholl f�r att �ppna d�rren
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")//om d�rrens hitbox r�r spelarens hitbox
        {
            reach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")//om spelaren l�mnar d�rrens hitbox
        {
            reach = false;
        }
    }
}
