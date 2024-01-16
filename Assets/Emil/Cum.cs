using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cum : MonoBehaviour
{
    float timer;
    PlayerMovement playermovement;
    bool active = true;
    private void Start()
    {
        playermovement = GetComponent<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void hahaL()
    {
        timer = 0;
        active = false;
        PlayerMovement.speed = 0;
        while (timer < 5)
        {
            timer += 1 * Time.deltaTime;
        }
        if (timer >= 5)
        {
            PlayerMovement.speed == 3;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player" && active == true)
        {
            hahaL();
        }
    }
}
