using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeContoller : MonoBehaviour
{
    [SerializeField]
    GameObject Green;
    [SerializeField]
    GameObject Yellow;
    [SerializeField]
    GameObject Orange;
    [SerializeField]
    GameObject Red;

    GameObject player;
    NoiseManager NoiseManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            NoiseManager = player.GetComponent<NoiseManager>();
        }

        if (NoiseManager != null)
        {
            if (NoiseManager.RobotActive == false)
            {
                Green.SetActive(true);
                Red.SetActive(false);
            }
           
            if (NoiseManager.spawn == true)
            {
                Red.SetActive(true);
                Orange.SetActive(false);
                Green.SetActive(false);
                Yellow.SetActive(false);
            }

            if (NoiseManager.totalNoise >= 20 && NoiseManager.totalNoise <= 39)
            {
                Yellow.SetActive(true);
                Green.SetActive(false);
            }

            if (NoiseManager.totalNoise >= 40 && NoiseManager.spawn != true)
            {
                Orange.SetActive(true);
                Yellow.SetActive(false);
            }
        }
       

       
    }
}
