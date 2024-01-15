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

    bool InReach;

    string EnterdCode;
    string rightCode;

    SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
        LockUI.SetActive(false);
        rightCode = "110901";
        WhenLockerOpen.SetActive(false);
        SR = GetComponent<SpriteRenderer>();

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
    }

    public void OnDigitChnage(string s) 
    {
        print("CodeEnterd");
        EnterdCode = s;
        print(EnterdCode);
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
    }
}
