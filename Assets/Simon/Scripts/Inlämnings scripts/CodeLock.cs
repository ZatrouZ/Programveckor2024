using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeLock : MonoBehaviour
{
    NoiseManager NoiseManager;
    [SerializeField]
    GameObject LockUI;
    GameObject KeyInHand;

    bool InReach;
   public bool hasCKey = false;

    string EnterdCode;
    public string rightCode = "110901";

    GameObject pipe;
    GameObject otherkey;
    GameObject player;
    bool hasUIUP;

    // Start is called before the first frame update
    void Start()
    {
        LockUI.SetActive(false); //st�nger av UIn f�r l�set i b�rjan
        StartCoroutine(Starting());//startar starting IEnumeratorn 
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)// om player inte �r n�got hotta object emd tagen player
        {
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            NoiseManager = FindObjectOfType<NoiseManager>();
        }

        if (KeyInHand == null)//om nyckel inte hittad hitta object med tag LRk (locker room key)
        {
            KeyInHand = GameObject.FindWithTag("LRK");
        }
        
        if (pipe == null)//samma som inann
        {
            pipe = GameObject.FindWithTag("PipeInHand");
        }
        
        if (otherkey == null)//samma som innan
        {
            otherkey = GameObject.FindWithTag("KeyInHand");
        }
       
        if (InReach == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && RealChat.isWriting == false)//om klikca e coh inte skriver i chatten
            {
                LockUI.SetActive(true);//s�tetr p� lock UIn
                hasUIUP = true;
                NoiseManager.totalNoise += 7;//h�jer noise managerns noise level (noise manager anv�ndes aldr�g)
            }
        }

        if (EnterdCode == rightCode)//om koden som �r skriven �r den r�tta koden starta funktionen
        {
            EnterdRightCode();
        }

        if (hasUIUP == true)//om Uin �r uppe och man klickar esc st�ngs UIn ner
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                LockUI.SetActive(false);
                hasUIUP = false;
            }
        }
    }

    public void OnDigitChnage(string s) //g�r s� att enterd code �r koden som skrivs i spelet
    {
        print("CodeEnterd");
        EnterdCode = s;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InReach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InReach = false;
        }
    }

    void EnterdRightCode() 
    {
        LockUI.SetActive(false);
        hasCKey = true;
        KeyInHand.SetActive(true);
    }

    IEnumerator Starting() //v�ntar i en skeund innan den st�nger av eftersom att spelaren inte finns direkt utan spawnas inn
    {
        yield return new WaitForSeconds(1);
        KeyInHand.SetActive(false);
        //pipe.SetActive(false);
        //otherkey.SetActive(false);
    }
}
