using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeLock : MonoBehaviour
{
    [SerializeField]
    GameObject LockUI;
    [SerializeField]
    GameObject StartBlackScreen;
    GameObject KeyInHand;

    bool InReach;
   public bool hasKey = false;

    string EnterdCode;
    public string rightCode = "110901";

    GameObject pipe;
    GameObject otherkey;
    bool hasUIUP;

    // Start is called before the first frame update
    void Start()
    {
        StartBlackScreen.SetActive(true);
        LockUI.SetActive(false);
        StartCoroutine(Starting());
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyInHand == null)
        {
            KeyInHand = GameObject.FindWithTag("LRK");
        }
        
        if (pipe == null)
        {
            pipe = GameObject.FindWithTag("PipeInHand");
        }
        
        if (otherkey == null)
        {
            otherkey = GameObject.FindWithTag("KeyInHand");
        }
       
        if (InReach == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LockUI.SetActive(true);
            }
        }

        if (EnterdCode == rightCode)
        {
            print("Unlock");
            EnterdRightCode();
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

    public void OnDigitChnage(string s) 
    {
        print("CodeEnterd");
        EnterdCode = s;
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

    void EnterdRightCode() 
    {
        LockUI.SetActive(false);
        hasKey = true;
        KeyInHand.SetActive(true);
    }

    IEnumerator Starting() 
    {
        yield return new WaitForSeconds(1);
        KeyInHand.SetActive(false);
        pipe.SetActive(false);
        otherkey.SetActive(false);
        StartBlackScreen.SetActive(false);
    }
}
