using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class cutscenenextscene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("StartingCells");
    }
}
