using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCellBlackScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        StartCoroutine(BlackScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BlackScreen() 
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
