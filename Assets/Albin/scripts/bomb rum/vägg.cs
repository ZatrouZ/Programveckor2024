using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class vägg : MonoBehaviour
{

    bomb bomb;

    PhotonView View;

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
        View = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reach == true)
        {
            if (bomb.hasBomb == true || bomb.hasBomb2 == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    View.RPC("RPC1", RpcTarget.All);
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
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            reach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            reach = false;
        }
    }

    [PunRPC]
    void RPC1() 
    {
        blackscreen.SetActive(true);
        timerstart = true;
    }

    
}
