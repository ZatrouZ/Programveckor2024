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
    bool isRed;
    // Start is called before the first frame update
    void Start()
    {
        isRed = false;
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
            if (NoiseManager.RobotActive == false && NoiseManager.totalNoise <= 19)
            {
                print("Green");
                Green.SetActive(true);
                Red.SetActive(false);
                isRed = false;
            }
           
            if (NoiseManager.spawn == true)
            {
                print("Red");
                Red.SetActive(true);
                Orange.SetActive(false);
                Green.SetActive(false);
                Yellow.SetActive(false);
                isRed = true;
            }

            if (NoiseManager.totalNoise >= 20 && NoiseManager.totalNoise <= 39 && isRed == false)
            {
                print("Yellow");
                Yellow.SetActive(true);
                Green.SetActive(false);
            }

            if (NoiseManager.totalNoise >= 40 && NoiseManager.spawn != true)
            {
                print("Orange");
                Orange.SetActive(true);
                Yellow.SetActive(false);
            }
        }
       
        
       
    }
}
