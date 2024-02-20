using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
 

public class TakenByRobotScript1 : MonoBehaviour
{
    GameObject player2;
    GameObject robot;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player2 = GameObject.FindWithTag("Player2");
        robot = GameObject.FindWithTag("robot");
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            SceneManager.LoadScene(13);


            
        }
      
    }
}
