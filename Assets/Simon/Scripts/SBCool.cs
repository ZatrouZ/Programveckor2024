using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBCool : MonoBehaviour
{
    [SerializeField]
    GameObject Manager;

    ReadySystem RS;
    // Start is called before the first frame update
    void Start()
    {
        RS = Manager.GetComponent<ReadySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
