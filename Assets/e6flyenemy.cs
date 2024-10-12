using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e6flyenemy : MonoBehaviour
{
    GameObject HorizontalEnemy;
    private soun SM;
    private UIContrpller ui;

    private Vector3 startPos;
    public Transform target;
    public float speed = 3f;
    private bool moveUp;
    bool dead;

    bool faceright = true , hit;


    private Animator anim;
    public float DeadDestroyTime = 2f;

    PlayerController player;
    public float rayLength = 1.5f; // Length of the ray
    public LayerMask collisionMask;

    void Start ( )
        {
        SM = FindObjectOfType<soun> ( );
        player = FindObjectOfType<PlayerController> ( );
        anim = GetComponent<Animator> ( );
        startPos = transform.position;
        moveUp = true;

        }
    void Update ( )
        {
       
                {
                float step = speed * Time.deltaTime;
                if (transform.position == target.position)
                    {
                    moveUp = false;
                    flip ( );
                    rayLength = +rayLength;
                    }
                else if (transform.position == startPos)
                    {
                    moveUp = true;
                    flip ( );
                    rayLength = -rayLength;
                    }
                if (moveUp == false)
                    {
                    transform.position = Vector3.MoveTowards ( transform.position,startPos,step );
                    }
                else if (moveUp)
                    {
                    transform.position = Vector3.MoveTowards ( transform.position,target.position,step );
                    }
                }
          
        }

    public void flip ( )
        {
        faceright = !faceright;

        Vector3 thescale = transform.localScale;

        thescale.x *= -1;

        transform.localScale = thescale;
        }

    private void OnTriggerEnter2D ( Collider2D collision )
        {

        if (collision.gameObject.tag == "mango" && !hit)
            {
            hit = true;
            SM.playSound ( SM.enemyblastsound );
            player.addKill ( );
            anim.Play ( "66die" );
            Destroy ( transform.parent.gameObject,DeadDestroyTime );
            }
        if (collision.gameObject.tag == "Player" && !hit)
            {
           
            SM.playSound ( SM.phurt );
            player.HelthReducer ( 1f,5 );
            //Destroy ( transform.parent.gameObject,DeadDestroyTime );
            }

        }
    }

//==================this is the horizontal enemy====================

// 1 . enemy should be designed as faced right.
// 2 . fill the target and target should be left to the player
// 3 . csript should attached to the enemy


