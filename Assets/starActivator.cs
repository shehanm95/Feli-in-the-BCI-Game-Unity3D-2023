using mymanager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starActivator : MonoBehaviour
{

    public GameObject star;
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
       if(collision.gameObject.tag == "Player")
            {
            star.SetActive ( true );
            GameManager.score = PlayerController.killCount * 5 + PlayerController.coin * 5 + PlayerController.currentHealth * 5;
            if (!Utils.mouthOpened)
                {
                ui.ReadLogText ( Message );
                }
            StartCoroutine ( Utils.waitSeanLoader ( "leaderboard",25f ) );
            }
        }
    }
