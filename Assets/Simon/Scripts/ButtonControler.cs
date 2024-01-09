using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler : MonoBehaviour
{
    [SerializeField]
    int OptionsManuScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionsOpen() 
    {
        SceneManager.LoadScene(OptionsManuScene);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
