using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Cell2Door : MonoBehaviour
{
    Cell2Key Cell2Key;

    [SerializeField]
    GameObject BackroundWithHole;
    [SerializeField]
    GameObject BackroundWithoutHole;
    bool open;
    PhotonView View;

    GameObject File;
    PhotonView PlayerView;
    GameObject player;
    GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Starting());
        View = GetComponent<PhotonView>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (File == null)
        {
            File = GameObject.FindWithTag("File");
        }
        if (open == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                View.RPC("RPC2", RpcTarget.All);
                SceneManager.LoadScene("Corridor 2(albin)");
            }
        }

        player2 = GameObject.FindWithTag("Player2");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2" && Cell2Key.hasKey == true)
        {
            open = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            open = false;
        }
    }

    IEnumerator Starting() 
    {
        yield return new WaitForSeconds(1.5f);
        Cell2Key = FindObjectOfType<Cell2Key>();
        View.RPC("RPC1", RpcTarget.All);
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerView = player.GetComponent<PhotonView>();
        if (PlayerView.IsMine == true)
        {
            this.enabled = false;
        }
    }

    [PunRPC]
    void RPC1() 
    {
        BackroundWithHole.SetActive(false);
    }
    [PunRPC]
    void RPC2()
    {
        BackroundWithHole.SetActive(true);
        File.SetActive(false);
        BackroundWithoutHole.SetActive(false);
        player2.SetActive(false);
    }
}
