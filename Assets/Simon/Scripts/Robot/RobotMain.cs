using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMain : MonoBehaviour
{
    [SerializeField]
    GameObject SpawnLocation;
    [SerializeField]
    GameObject Robot;
    hidingplace hidingplace;
    hidingplace2 hidingplace2;
    NoiseManager NoiseManager;
    // Start is called before the first frame update
    void Start()
    {
        hidingplace = GetComponent<hidingplace>();
        hidingplace2 = GetComponent<hidingplace2>();
        NoiseManager = GetComponent<NoiseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hidingplace.hiding == true || hidingplace2.hiding == true)
        {

        } 
    }
    
    void Spawn() 
    {
    
    }

    void DeSpawn() 
    {
    
    }
}
