using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptE1 : MonoBehaviour
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

    void Start()
    {
        SM = FindObjectOfType<soun>();
        player = FindObjectOfType<PlayerController> ();
        anim = GetComponent<Animator>();
        startPos = transform.position;
        moveUp = true;

    }
    void Update()
    {
        //print ( transform.position );
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, rayLength, collisionMask);

        if (!dead)
            {
            if (hit.collider != null)
                {
                print ( "playerhit" );
                anim.Play ( "E1attack" );
                player.HelthReducer ( 1f,3 );
                
                }

            else
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
    }

    public void flip()
    {
        faceright = !faceright;

        Vector3 thescale = transform.localScale;

        thescale.x *= -1;

        transform.localScale = thescale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "mango" && !hit)
        {
            hit = true;
            SM.playSound ( SM.enemyblastsound);
            player.addKill ( );
            anim.Play ( "E1die" );
            Destroy(transform.parent.gameObject, DeadDestroyTime);
           

        }

    }
}

//==================this is the horizontal enemy====================

// 1 . enemy should be designed as faced right.
// 2 . fill the target and target should be left to the player
// 3 . csript should attached to the enemy

