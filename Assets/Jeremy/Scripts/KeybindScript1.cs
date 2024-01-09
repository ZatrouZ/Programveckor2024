using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KeybindScript1 : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI buttonLbl;

    public static KeyCode up;
    public static KeyCode down;
    public static KeyCode right;
    public static KeyCode left;
    public static KeyCode jump;

    bool ChangeUp;
    bool ChangeDown;
    bool ChangeRight;
    bool ChangeLeft;
    bool ChangeJump;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        foreach ( KeyCode key in Enum.GetValues(typeof( KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                if (ChangeUp)
                {
                    up = key;
                    ChangeUp = false;
                }
                else if (ChangeDown)
                {
                    down = key;
                    ChangeDown = false;
                }
                else if(ChangeRight)
                {
                    right = key;
                    ChangeRight = false;
                } 
                else if (ChangeLeft)
                {
                    left = key;
                    ChangeLeft = false;
                }
                else if (ChangeJump)
                {
                    jump = key;
                    ChangeJump = false;
                }
               
            }
        }
    }

    public void ForwardButton()
    {
        ChangeUp = true;
    }
    public void BackwardButton()
    {
        ChangeDown = true;
    }
    public void RightButton()
    {
        ChangeDown = true;
    }
    public void LeftButton()
    {
        ChangeDown = true;
    }
    public void JumpButton()
    {
        ChangeDown = true;
    }

}
