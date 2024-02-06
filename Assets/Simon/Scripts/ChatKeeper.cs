using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ChatKeeper : MonoBehaviour
{
    [SerializeField]
    int NumberForChatScene;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(NumberForChatScene, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
