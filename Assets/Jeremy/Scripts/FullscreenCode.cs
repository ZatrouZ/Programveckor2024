using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullscreenCode : MonoBehaviour
{

    public static FullscreenCode instance;
    public void FullscreenSettings()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
        
}
