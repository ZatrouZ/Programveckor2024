using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("onStart");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator onStart() 
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("SlutSlutScene");
    }
}
