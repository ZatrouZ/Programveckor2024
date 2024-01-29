using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OverheadItemRemoval : MonoBehaviour
{
    
    GameObject File;
    GameObject KeyInHand;
    GameObject PipeInHand;
    GameObject CodeLockKey;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (File == null)
        {
            File = GameObject.FindWithTag("File");
        }
        else
        {
            File.SetActive(false);
        }

        if (KeyInHand == null)
        {
            KeyInHand = GameObject.FindWithTag("KeyInHand");
        }
        else
        {
            KeyInHand.SetActive(false);
        }

        if (PipeInHand == null)
        {
            PipeInHand = GameObject.FindWithTag("PipeInHand");
        }
        else
        {
            PipeInHand.SetActive(false);
        }

        if (CodeLockKey == null)
        {
            CodeLockKey = GameObject.FindWithTag("LRK");
        }
        else
        {
            CodeLockKey.SetActive(false);
        }
    }
}
