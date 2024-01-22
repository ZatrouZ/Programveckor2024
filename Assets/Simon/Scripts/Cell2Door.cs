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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Starting());
        View = GetComponent<PhotonView>();
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerView = player.GetComponent<PhotonView>();
        if (PlayerView.IsMine == true)
        {
            this.enabled = false;
        }
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Cell2Key.hasKey == true)
        {
            open = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            open = false;
        }
    }

    IEnumerator Starting() 
    {
        yield return new WaitForSeconds(1.5f);
        Cell2Key = FindObjectOfType<Cell2Key>();
        View.RPC("RPC1", RpcTarget.All);
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
    }
}
