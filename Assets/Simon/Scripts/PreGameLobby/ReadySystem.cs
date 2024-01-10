using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ReadySystem : MonoBehaviourPunCallbacks
{
    [SerializeField]
    TMP_Text playersInLobby;
    [SerializeField]
    TMP_Text playersReady;
    [SerializeField]
    TMP_Text timerText;
    [SerializeField]
    GameObject timerObj;

    bool isReady = false;
    int readyPlayers = 0;
    float timer = 5;
    bool timerZero;
    bool stopTimer = false;
    PhotonView view;

    ButtonChangeColor _BCC;

    [SerializeField]
    GameObject button;

    [SerializeField]
    int GameScene;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        _BCC = button.GetComponent<ButtonChangeColor>();
        timerObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.ToString("0");
        playersInLobby.text = PhotonNetwork.PlayerList.Length.ToString();
        playersReady.text = readyPlayers.ToString();
        if (readyPlayers == PhotonNetwork.PlayerList.Length && stopTimer == false)
        {
            timerObj.SetActive(true);
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 5;
            timerObj.SetActive(false);
        }

        if (timer <= 0)
        {
            timer = 0;
            timerZero = true;
            stopTimer = true;
        }

        if (timerZero == true)
        {
            OnTimerZero();
            timerZero = false;
        }
    }

    [PunRPC]
    void ChangeReadyPlayer(bool isReady)
    {
        if (isReady)
        {
            readyPlayers++;
        }
        else
        {
            readyPlayers--;
            if (readyPlayers < 0)
            {
                readyPlayers = 0;
            }
        }
    }

    public void OnButtonPress()
    {
            if (isReady == false)
            {
                isReady = true;
                view.RPC("ChangeReadyPlayer", RpcTarget.AllBuffered, true);
                _BCC.ChangeColorToGreen();
            }
            else
            {
                isReady = false;
                view.RPC("ChangeReadyPlayer", RpcTarget.AllBuffered, false);
                _BCC.ChangeColorToRed();
            }
        
    }

    void OnTimerZero() 
    {
        if (PhotonNetwork.IsMasterClient)
        {
            print("starting game");
            PhotonNetwork.LoadLevel(GameScene);
        }
    }
}
