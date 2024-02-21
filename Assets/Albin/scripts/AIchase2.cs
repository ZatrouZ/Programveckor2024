using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIchase2 : MonoBehaviour
{
    public GameObject player;

    public float speed;

    hidingplace hiding;

    EnemyPatrol patrol;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        patrol = GetComponent<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player2");



        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (hiding == false) //If distance is 8 or closer. This object where this script is placed will start following the player. However if further away than distance 9 it will stop following you.
        {

            //patrol.enabled = false; //EnemyPatrol Disables
            //FindObjectOfType<AIChase>().enabled = true; //Ai chase script enables
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            patrol.enabled = true;
            FindObjectOfType<AIChase2>().enabled = false;
        }



    }
}
