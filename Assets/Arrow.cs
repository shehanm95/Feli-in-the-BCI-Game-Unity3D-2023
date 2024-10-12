using System.Collections.Generic;
using UnityEngine;
public class Arrow: MonoBehaviour
    {
    public GameObject player;
    public GameObject target;
    public float speed = 10f;
    public Vector3 movePosition;
    private float playerX;
    private float targetX;
    private float nextX;
    private float dist;
    private float baseY;
    private float height;
    float activetime , Addtime = 1f;
    bool hit;

    // Start is called before the first frame update
    void Start ( )
        {
        activetime = Time.time + Addtime;
        player = GameObject.FindGameObjectWithTag ( "Player" );
        
        }
    // Update is called once per frame
    void Update ( )
        {
        if (Time.time < activetime || !hit)
            {
            playerX = player.transform.position.x;
            targetX = PlayerController.target.x;
            dist = targetX - playerX;
            nextX = Mathf.MoveTowards ( transform.position.x,targetX,speed * Time.deltaTime );
            baseY = Mathf.Lerp ( player.transform.position.y,PlayerController.target.y,(nextX - playerX) / dist );
            height = 2 * (nextX - playerX) * (nextX - targetX) / (-0.25f * dist * dist);
            movePosition = new Vector3 ( nextX,baseY + height,transform.position.z );
            transform.rotation = LookAtTarget ( movePosition - transform.position );
            transform.position = movePosition;
            }
        
          
        }
    public static Quaternion LookAtTarget ( Vector2 r )
        {
        return Quaternion.Euler ( 0,0,Mathf.Atan2 ( r.y,r.x ) * Mathf.Rad2Deg );
        }

    void OnCollisionEnter2D ( Collision2D collision )
        {
        // Enemy collision detection
        if (collision.gameObject.CompareTag ( "Enemy" ))
            {
            // Reduce health of the player on collision with an enemy
            print ( "hit una");
            hit = true;
            Destroy ( gameObject,2f );
            }
        }

    }
