using mymanager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercollision : MonoBehaviour
{
    public PlayerController player;
    public UIContrpller ui;
    soun sm;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<soun> ( );
        anim = GetComponent<Animator> ( );
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D ( Collision2D collision )
        {
        // Enemy collision detection
        if (collision.gameObject.CompareTag ( "Enemy" ))
            {
            // Reduce health of the player on collision with an enemy
            //player.TakeDamage ( 10 ); // Adjust the damage value as needed
            }
        if (collision.gameObject.CompareTag ( "coin" ))
            {
            // Reduce health of the player on collision with an enemy
            PlayerController.coin++;
            ui.updateCoinText ( );
            sm.playSound ( sm.coin );
            collision.gameObject.SetActive ( false );
            }

        }

    private void OnCollisionStay2D ( Collision2D collision )
        {
        if (collision.gameObject.CompareTag ( "Water" ))
            {
            print ( "water collied" );
            // Reduce health of the player on collision with an enemy
            player.HelthReducer ( 1f,30 );
            player.sunked = true;
            }
        if (collision.gameObject.CompareTag ( "Enemy" ))
            {
            print ( "enemy collied stay" );
            // Reduce health of the player on collision with an enemy
            player.HelthReducer ( 1f,3 );
            }
        if (collision.gameObject.CompareTag ( "dethground" ))
            {
            print ( "dethground collied stay" );
            // Reduce health of the player on collision with an enemy
            player.HelthReducer ( 0.1f,100 );
            }
        if (collision.gameObject.CompareTag ( "fire" ))
            {
            print ( "fire collied stay" );
            // Reduce health of the player on collision with an enemy
            player.HelthReducer ( 1f,10 );
            }

        }
    private void OnCollisionExit2D ( Collision2D collision )
        {
        if (collision.gameObject.CompareTag ( "Water" ))
            {
            print ( "water exit" );
            player.sunked = false;
            }
        }

    private void OnTriggerEnter2D ( Collider2D collision )
        {
        if(collision.gameObject.tag == "coin")
            {
            sm.playSound ( sm.coin );
            PlayerController.coin++;
            ui.updateCoinText ( );
            Destroy ( collision.gameObject );
            }
        }


    }
