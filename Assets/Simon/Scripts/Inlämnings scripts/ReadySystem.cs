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
        view = GetComponent<PhotonView>(); //tar objectets PhotonView för att använda RPC
        _BCC = button.GetComponent<ButtonChangeColor>();//Kollpar med ButtonChangeColor scriptet
        timerObj.SetActive(false); //stänger av timern i scenen
        playersInLobby.text = "2"; //den här kan man sätta till PhotonNetwork.PlayerList.Length om man vill att så många som är i lobbyn ska behöva blir ready
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.ToString("0");//gör så att timer TMPn blir till samma som timern i scriptet med inga decimaler
        //playersInLobby.text = PhotonNetwork.PlayerList.Length.ToString();
        playersReady.text = readyPlayers.ToString();//gör så att players rady TMPn har samma värde som i scriptet
       // \/ om både spelarna är ready och stop timer är false
        if (readyPlayers == 2 && stopTimer == false)//readyPlayers kan vara PhotonNetwork.PlayerList.Length om man vill ha mer än två
        {
            timerObj.SetActive(true);//sätter igång TMPn för timern
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 5;//om alla inte är ready så blir timern tillbaka till 5
            timerObj.SetActive(false);//stänger av timer TMPn
        }

        if (timer <= 0)//när timern når noll
        {
            timer = 0;//gör så att timern int eblir minus
            timerZero = true;//bool för om timern nått noll
            stopTimer = true;//stoppa timern
        }

        if (timerZero == true)
        {
            OnTimerZero();
            timerZero = false;//gör så att OnTimerZero funktionen inte händer fler gånger
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
                view.RPC("ChangeReadyPlayer", RpcTarget.AllBuffered, true);//startar RPC med isRady true
                _BCC.ChangeColorToGreen();
            }
            else
            {
                isReady = false;
                view.RPC("ChangeReadyPlayer", RpcTarget.AllBuffered, false);//startar RPC med isReady false
                _BCC.ChangeColorToRed();
            }
        
    }

    void OnTimerZero() 
    {
        if (PhotonNetwork.IsMasterClient)//gör så att bara masterclient loadar scenen
        {
            print("starting game");
            PhotonNetwork.LoadLevel(GameScene);//gör så att scenen loads för båda
        }
    }
}
