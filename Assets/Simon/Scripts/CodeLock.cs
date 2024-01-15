using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeLock : MonoBehaviour
{
    [SerializeField]
    GameObject LockUI;
    [SerializeField]
    GameObject Door;
    [SerializeField]
    GameObject WhenLockerOpen;
    [SerializeField]
    GameObject LockerDoor;
    [SerializeField]
    GameObject KeyInLocker;
    [SerializeField]
    GameObject KeyInHand;

    bool InReach;
    bool hasOpendLocker;
   public bool hasKey = false;

    string EnterdCode;
    public string rightCode = "110901";

    SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
        LockUI.SetActive(false);
        WhenLockerOpen.SetActive(false);
        SR = GetComponent<SpriteRenderer>();
        KeyInHand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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

        if (hasOpendLocker == true && InReach == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                KeyInLocker.SetActive(false);
                KeyInHand.SetActive(true);
                hasKey = true;
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
        WhenLockerOpen.SetActive(true);
        LockerDoor.SetActive(false);
        SR.enabled = false;
        hasOpendLocker = true;
    }
}
