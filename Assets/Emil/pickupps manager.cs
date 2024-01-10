using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickuppsmanager : MonoBehaviour
{
    bool holdingItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1,0,0) * Time.deltaTime;
    }
    private void OntriggerEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            holdingItem = true;
            
        }
    }
    //std = items
    class std
    {
        public string itemName;
    }
}
