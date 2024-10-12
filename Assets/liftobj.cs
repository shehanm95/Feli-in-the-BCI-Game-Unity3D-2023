using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftobj : MonoBehaviour
    {

    public GameObject platform ,  topFloor , FullLift , DethGround;

    private Vector3 startPos;
    public Transform target;
    public float speed , liftOpenTime;
    private bool moveUp;
    bool moving =false;
    public GameObject liftTopCollider;
    Animator anim;
    private bool liftOpened;

    void Start ( )
        {
        anim = GetComponent<Animator> ( );
        startPos = transform.position;
        moveUp = true;
        }
    void Update ( )
        {
        if (moving)
            {
            float step = speed * Time.deltaTime;
            if (transform.position == target.position)
                {
                moveUp = false;
                }
            else if (transform.position == startPos)
                {
                moveUp = true;
                }
            if (moveUp == false)
                {
                if (!liftOpened)
                    {
                    liftOpened = true;
                    anim.Play ( "lipftOpen" );
                    StartCoroutine ( liftopen ( ) );
                    }

                }
            else if (moveUp)
                {
                transform.position = Vector3.MoveTowards ( transform.position,target.position,step );  // can make with Larp
                }
            }
        }

    private void OnTriggerStay2D ( Collider2D collision )
        {
        if (collision.gameObject.tag == "Player")
            {
            Invoke ( "liftmove",1.5f );
            }
        }

    private void OnTriggerExit2D ( Collider2D collision )
        {
        if (collision.gameObject.tag == "Player")
            {
            moving = false;
            }
        }


    IEnumerator liftopen ( )
        {
        yield return new WaitForSeconds ( liftOpenTime );
        topFloor.SetActive ( true );
        DethGround.SetActive ( true );
        liftTopCollider.SetActive ( false );
        yield return new WaitForSeconds ( 6f );
        Destroy ( FullLift );

        }

    void liftmove ( )
        {
        moving = true;
        }

    }
