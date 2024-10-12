using mymanager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageReader : MonoBehaviour
{
    [TextArea]
    public string Message;
    UIContrpller ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIContrpller> ( );
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerStay2D ( Collider2D collision )
        {
        
            if (collision.gameObject.tag == "Player")
            {if (!Utils.mouthOpened)
                {   
               
                print ( "called" );
                ui.ReadLogText ( Message );
                gameObject.SetActive ( false );
                }
            }
        }
    }
