using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//Denna kod g�r s� att spelet kan switcha emellan fullscreen och icke fullscreen.
public class FullscreenCode : MonoBehaviour
{

    public static FullscreenCode instance;
    public void FullscreenSettings()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
        
}
