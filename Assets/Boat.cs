using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private soun SM;
    private UIContrpller ui;

    private Vector3 startPos;
    public Transform target;
    public float speed = 3f;
    private bool moveUp;
    public float rayLength = 1.5f; // Length of the ray
    public LayerMask collisionMask;
    private bool entered;

    void Start ( )
        {
        SM = FindObjectOfType<soun> ( );
        startPos = transform.position;
        moveUp = true;

        }
    void Update ( )
        {
        if (entered) { 
                float step = speed * Time.deltaTime;
                if (transform.position == target.position)
                    {
                    moveUp = false;
                 
                    rayLength = +rayLength;
                    }
                else if (transform.position == startPos)
                    {
                    moveUp = true;
                  
                    rayLength = -rayLength;
                    }
            if (moveUp == false)
                {
                //transform.position = Vector3.MoveTowards ( transform.position,startPos,step );
                }
            else if (moveUp)
                {
                transform.position = Vector3.MoveTowards ( transform.position,target.position,step );
                }
        }
    }




    private void OnTriggerStay2D ( Collider2D collision )
        {
        if (collision.gameObject.tag == "Player")
            {
            print ( "collied" );
            //collision.transform.SetParent ( transform );
            entered = true;
            }

        }

    private void OnTriggerExit2D ( Collider2D collision )
        {

        if (collision.gameObject.tag == "Player")
            {
            
            //collision.transform.SetParent ( transform );
            entered = false;
            }

        }
    }

//==================this is the horizontal enemy====================

// 1 . enemy should be designed as faced right.
// 2 . fill the target and target should be left to the player
// 3 . csript should attached to the enemy

