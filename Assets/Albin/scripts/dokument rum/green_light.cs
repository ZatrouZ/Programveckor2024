using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class green_light : MonoBehaviour
    //Albin men anv�nds inte 
{ 
    [SerializeField]
    GameObject green;

    bool reach = false;
    // Start is called before the first frame update
    void Start()
    {
        green.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
       
            
            if (reach == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("sista rum(albin)");
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
