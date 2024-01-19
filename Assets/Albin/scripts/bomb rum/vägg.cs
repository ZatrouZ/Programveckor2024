using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vägg : MonoBehaviour
{

    bomb bomb;

    [SerializeField]
    GameObject blackscreen;

    bool reach = false;
    float timer = 2;
    bool timerstart = false;
    // Start is called before the first frame update
    void Start()
    {
        bomb = FindObjectOfType<bomb>();
        blackscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (reach == true)
        {
            if (bomb.hasBomb==true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    blackscreen.SetActive(true);
                    bomb.boom = true;
                    timerstart = true;
                }
            }  
        }
        if (timerstart==true)
        {
            timer -= Time.deltaTime;
        }
        if (timer<0)
        {
            SceneManager.LoadScene("slut cutscene");
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
