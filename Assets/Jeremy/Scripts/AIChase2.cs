using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AIChase2 : MonoBehaviour
{

    
    public GameObject player2;


    public float speed;
    

    private float distance1;
    private float distance2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        distance1 = Vector2.Distance(transform.position, player2.transform.position);
        Vector2 direction = player2.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance1 < 4) //If distance is 4 or closer. This object where this script is placed will start following the player. However if further away than distance 5 it will stop following you.
        {
            GetComponent<EnemyPatrol>().enabled = false; //EnemyPatrol Disables
            GetComponent<AIChase2>().enabled = true; //Ai chase script enables
            transform.position = Vector2.MoveTowards(this.transform.position, player2.transform.position, speed * Time.deltaTime);
    
        }
        else if(distance1 >= 5)
        {
            GetComponent<EnemyPatrol>().enabled = true; //EnemyPatrol Enables again if object is further away than distance 5.
            //GetComponent<AIChase2>().enabled = false;
            
        }
        


    }
}
