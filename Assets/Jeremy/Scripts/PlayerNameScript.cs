using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerNameScript : MonoBehaviour
{
    public InputField nameInput;
    public Button setNameButton;

    public void OnNameChange(string value)
    {
        if(value.Length > 3)
        {
            print("Can now type in Nickname");
            setNameButton.interactable = true;

        }
    }

    public void OnClick_SetName()
    {
        print("Nickname Changed!");
        PhotonNetwork.NickName = nameInput.text;
    }

}
