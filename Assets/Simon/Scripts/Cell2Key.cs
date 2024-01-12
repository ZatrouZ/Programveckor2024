using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2Key : MonoBehaviour
{
    //detta script är en kopia av albins key scripts med några endringar
    Cell2LooseTile LT;

    [SerializeField]
    public GameObject keyInHand;

    bool reach;
    public bool hasKey;
    // Start is called before the first frame update
    void Start()
    {
        LT = FindObjectOfType<Cell2LooseTile>();
        keyInHand.SetActive(false);
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LT.hasMovedTile == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                gameObject.SetActive(false);
                keyInHand.SetActive(true);
                hasKey = true;
            }
        }
    }
   
}
