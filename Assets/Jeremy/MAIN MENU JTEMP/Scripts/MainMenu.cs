using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //Load Next Scene after clicking assigned button.

    }

    public void QuitGame()
    {
        Application.Quit(); //Quit game after clicking assigned button.

    }
    
}
