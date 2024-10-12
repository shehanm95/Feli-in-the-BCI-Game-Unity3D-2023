using UnityEngine;

public class ThrowProjectile: MonoBehaviour
    {
    Rigidbody2D rb;
    private void Start ( )
        {
        rb = GetComponent<Rigidbody2D> ( );
        Destroy ( gameObject,2.5f );
        }

    void OnCollisionEnter2D ( Collision2D collision )
        {
        // Enemy collision detection
       
        if(collision.gameObject.tag == "Enemy")
            {

            rb.velocity = Vector2.zero;
           // print ( "collied something" );
            }
       
        }
    }
