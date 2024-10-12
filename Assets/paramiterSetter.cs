using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paramiterSetter : MonoBehaviour
{
    CameraFollow cam;
    public float smoothtime =0f;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<CameraFollow> ( );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D ( Collider2D collision )
        {
        if(collision.gameObject.tag == "Player")
            {
            print ( "enterd" );
            cam.smoothTime =smoothtime;
            }
        }
    }
