using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftactivator : MonoBehaviour
{
    public GameObject Lift;
    public Transform LiftPlatform;
    GameObject player;
    private PlayerController con;
    bool move;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ( "Player" );
        con = FindObjectOfType<PlayerController> ( );
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D ( Collider2D collision )
        {
        if(collision.gameObject.tag == "Player")
            {

            con.playerminX = con.playerminX - 300f;
            FindObjectOfType<PlayerController> ( ).maxleflimit = 230f;
            Lift.SetActive ( true );
            collision.transform.position = LiftPlatform.position;
            Destroy ( gameObject );
            }
        }
    }
