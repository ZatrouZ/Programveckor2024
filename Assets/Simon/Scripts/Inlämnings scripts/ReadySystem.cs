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
        view = GetComponent<PhotonView>(); //tar objectets PhotonView f�r att anv�nda RPC
        _BCC = button.GetComponent<ButtonChangeColor>();//Kollpar med ButtonChangeColor scriptet
        timerObj.SetActive(false); //st�nger av timern i scenen
        playersInLobby.text = "2"; //den h�r kan man s�tta till PhotonNetwork.PlayerList.Length om man vill att s� m�nga som �r i lobbyn ska beh�va blir ready
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.ToString("0");//g�r s� att timer TMPn blir till samma som timern i scriptet med inga decimaler
        //playersInLobby.text = PhotonNetwork.PlayerList.Length.ToString();
        playersReady.text = readyPlayers.ToString();//g�r s� att players rady TMPn har samma v�rde som i scriptet
       // \/ om b�de spelarna �r ready och stop timer �r false
        if (readyPlayers == 2 && stopTimer == false)//readyPlayers kan vara PhotonNetwork.PlayerList.Length om man vill ha mer �n tv�
        {
            timerObj.SetActive(true);//s�tter ig�ng TMPn f�r timern
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 5;//om alla inte �r ready s� blir timern tillbaka till 5
            timerObj.SetActive(false);//st�nger av timer TMPn
        }

        if (timer <= 0)//n�r timern n�r noll
        {
            timer = 0;//g�r s� att timern int eblir minus
            timerZero = true;//bool f�r om timern n�tt noll
            stopTimer = true;//stoppa timern
        }

        if (timerZero == true)
        {
            OnTimerZero();
            timerZero = false;//g�r s� att OnTimerZero funktionen inte h�nder fler g�nger
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
        if (PhotonNetwork.IsMasterClient)//g�r s� att bara masterclient loadar scenen
        {
            print("starting game");
            PhotonNetwork.LoadLevel(GameScene);//g�r s� att scenen loads f�r b�da
        }
    }
}
