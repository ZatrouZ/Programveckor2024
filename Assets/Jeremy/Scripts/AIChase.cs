using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AIChase : MonoBehaviour
{

    public GameObject player;
    
    public float speed;

    

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < 8) //If distance is 8 or closer. This object where this script is placed will start following the player. However if further away than distance 9 it will stop following you.
        {
            GetComponent<EnemyPatrol>().enabled = false; //EnemyPatrol Disables
            GetComponent<AIChase>().enabled = true; //Ai chase script enables
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    
        }
        else if(distance >= 9)
        {
            GetComponent<EnemyPatrol>().enabled = true; //EnemyPatrol Enables again if object is further away than distance 9.
            
            
        }
        


    }
}
