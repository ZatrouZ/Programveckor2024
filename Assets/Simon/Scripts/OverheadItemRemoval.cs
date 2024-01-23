using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OverheadItemRemoval : MonoBehaviour
{
    GameObject Bomb;
    GameObject Bomb2;
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
        if (Bomb == null)
        {
            Bomb = GameObject.FindWithTag("Bomb");
        }
        else
        {
            Bomb.SetActive(false);
        }
        if (Bomb2 == null)
        {
            Bomb2 = GameObject.FindWithTag("Bomb2");
        }
        else
        {
            Bomb2.SetActive(false);
        }
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
