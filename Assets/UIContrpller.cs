using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using mymanager;

public class UIContrpller : MonoBehaviour
{
    public TMP_Text helthText , coinText , EnemyKillCountText , LogText;
    public Slider HelthSlider;
    public Image HelthsliderImage;
    public soun sm;
    AudioSource au;
    bool helthLoaded;
    public GameObject MouthOpenedImage;

    // Start is called before the first frame update
    void Start()
    {
        sm = sm.GetComponent<soun> ( );
        au = GetComponent<AudioSource> ( );
        updateHelthText ( );
        helthLoaded = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHelthText ( )
        {
        if (PlayerController.currentHealth > 0)
            {
            helthText.text = PlayerController.currentHealth.ToString ( "00" );
            HelthSlider.value = PlayerController.currentHealth;
            if (helthLoaded)
                sm.playSound ( sm.phurt );
            if (PlayerController.currentHealth < 10)
                {
                HelthsliderImage.color = Color.red;
                }
            }
        else
            {
            helthText.text = "00";
            GameManager.score = PlayerController.killCount * 5 + PlayerController.coin * 5 + PlayerController.currentHealth * 5;
            GameManager.gameover = true;
            }
        }
    public void updateCoinText ( )
        {
        coinText.text = "Coins        : "+ PlayerController.coin.ToString ( "00" );
        
        }

    public void updateKillCountText ( )
        {
        EnemyKillCountText.text = "Enemy Kills  : " + PlayerController.killCount.ToString ( "00" );

        }


    public void ReadLogText (string Message )
        {
        StartCoroutine( Utils.RevealText ( Message,LogText,au ));
        StartCoroutine ( rasikaTalk ( ) );
        }

    IEnumerator rasikaTalk ( )
        {
        while (Utils.mouthOpened)
            {
            MouthOpenedImage.SetActive ( false );
            float t = Random.Range(0.6f , 0.2f);
            yield return new WaitForSeconds ( t );
            MouthOpenedImage.SetActive ( true );
            t = Random.Range(0.6f , 0.2f);
            yield return new WaitForSeconds ( t );
            }
        MouthOpenedImage.SetActive ( false );
        }
    }
