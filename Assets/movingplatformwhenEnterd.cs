using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatformwhenEnterd : MonoBehaviour
    {

    public GameObject platform;

    private Vector3 startPos;
    public Transform target;
    public float speed;
    private bool moveUp;
    bool moving =false;
    CameraFollow cam;
    public float cameraYoffsetStay ,cameraYoffsetExit ;
    private bool entered;

    void Start ( )
        {
        cam = FindObjectOfType<CameraFollow> ( );
        cameraYoffsetExit = cam.yOffSet;
        startPos = transform.position;
        moveUp = true;
        }
    void Update ( )
        {
        if (moving) {
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
               // transform.position = Vector3.MoveTowards ( transform.position,startPos,step );  // can make with Larp
                }
            else if (moveUp)
                {
                transform.position = Vector3.MoveTowards ( transform.position,target.position,step );  // can make with Larp
                }
            }
        }

    private void OnTriggerEnter2D ( Collider2D collision )
        {
        if (collision.gameObject.tag == "Player")
            {
            if (!entered)
                {
                collision.transform.position = new Vector2 ( gameObject.transform.position.x,gameObject.transform.position.y + 1 );
                entered = true;
                } }
        }

    private void OnTriggerStay2D ( Collider2D collision )
        {
        if(collision.gameObject.tag == "Player")
            {
            moving = true;
            cam.yOffSet =  cameraYoffsetStay;
            
            }
        }

    private void OnTriggerExit2D ( Collider2D collision )
        {
        if (collision.gameObject.tag == "Player")
            {
            cam.yOffSet = cameraYoffsetExit;
            moving = false;
            }
        }

    }