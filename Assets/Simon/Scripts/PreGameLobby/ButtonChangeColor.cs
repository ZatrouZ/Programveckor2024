using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChangeColor : MonoBehaviour
{
    [SerializeField]
    GameObject button;

    public void ChangeColorToRed()
    {
        button.GetComponent<Image>().color = Color.red;
    }

    public void ChangeColorToGreen() 
    {
        button.GetComponent<Image>().color = Color.green;
    }
}
