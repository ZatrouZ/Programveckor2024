using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interract : MonoBehaviour
{
    protected bool reach = false;//bool för om du är inom räckholl för att öppna dörren
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")//om dörrens hitbox rör spelarens hitbox
        {
            reach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")//om spelaren lämnar dörrens hitbox
        {
            reach = false;
        }
    }
}
