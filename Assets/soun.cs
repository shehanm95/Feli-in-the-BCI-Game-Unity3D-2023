using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soun : MonoBehaviour
{
    public AudioClip phurt , pjump , enemyblastsound , coin , dieSound;
    public AudioSource au;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(AudioClip audioClip)
        {
        au.PlayOneShot ( audioClip);
        }





}
