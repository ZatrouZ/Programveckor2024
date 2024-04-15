using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock2 : MonoBehaviour
{
    public AudioSource audioSource;
    NoiseManager NoiseManager;
    bool InReach;
    [SerializeField]
    GameObject LockUI;
    GameObject player;

    bool hasUIUP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            NoiseManager = FindObjectOfType<NoiseManager>();
        }
        if (InReach == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && RealChat.isWriting == false)
            {
                LockUI.SetActive(true);
                hasUIUP = true;
                NoiseManager.totalNoise += 7;
                audioSource.Play();
            }
        }

        if (hasUIUP == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                LockUI.SetActive(false);
                hasUIUP = false;
            }
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InReach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InReach = false;
        }
    }
}
