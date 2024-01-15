using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2Key : MonoBehaviour
{
    //detta script �r en kopia av albins key scripts med n�gra endringar
    Cell2LooseTile LT;

    GameObject File;

    bool reach;
    public bool hasKey;
    // Start is called before the first frame update
    void Start()
    {
        LT = FindObjectOfType<Cell2LooseTile>();
        hasKey = false;
        File = GameObject.FindWithTag("File");
        File.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (LT.hasMovedTile == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                gameObject.SetActive(false);
                File.SetActive(true);
                hasKey = true;
            }
        }
    }
   
}
