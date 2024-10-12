using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class objectactivator : MonoBehaviour
{
    public GameObject[] ObjectToActivate;
    public GameObject[] ObjectToDeActivate;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter2D ( Collider2D collision )
        {
        if(collision.gameObject.tag == "Player")
            {
            foreach(GameObject g in ObjectToActivate)
                {
                g.SetActive ( true );
                }
            foreach (GameObject g in ObjectToDeActivate)
                {
                Destroy ( g);
                }
            Destroy ( gameObject );
            }
        }
    }
