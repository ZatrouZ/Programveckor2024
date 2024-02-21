using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doortodocuments : interract
    //Albin
{
    private void Update()
    {
        if (reach == true)
        {
            if (Input.GetKey(KeyCode.E) && RealChat.isWriting == false)
            {
                SceneManager.LoadScene("dokument rum");
            }
        }
    }
}
