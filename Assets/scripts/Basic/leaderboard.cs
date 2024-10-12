using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using mymanager;
using System.Linq;

public class leaderboard : MonoBehaviour
{
    int listcapacity , playerindex;
    List<Player> players =new List<Player>();
    public TMP_Text leaderBoardText , log;
    string leaterboardString;
    public GameObject tryAgainButton , NextButton;
    AudioSource au;

    public GameObject textTemplate , LeaderBoardContent , StarparticleSystem;
    


    // Start is called before the first frame update
    void Start()
    {
        listcapacity = GameManager.listcapacity;
        StarparticleSystem.SetActive ( false );
        NextButton.SetActive ( false );
        tryAgainButton.SetActive ( false );
        au = GetComponent<AudioSource> ( );
        int maxtrys = PlayerPrefs.GetInt("maxtries",3);
        print ( GameManager.round + " and tries are : " + maxtrys );
        if (GameManager.round < maxtrys)
            tryAgainButton.SetActive ( true );
        else
            NextButton.SetActive ( true );
            

     for(int i = 0 ; i < listcapacity ; i++)
            {
            Player player = new Player( PlayerPrefs.GetString("fname" + i.ToString() , "nisal") , PlayerPrefs.GetString("lname" + i.ToString() , "Perera"), PlayerPrefs.GetInt("score" + i.ToString(), (20-i)));
            players.Add ( player );
            }

        

        if (GameManager.score > players[listcapacity -1].Score)
            {
            //victorysound playing
            au.PlayOneShot ( SoundManager.bgmusic );
            insertToLeaderBoard ( );
            saveplayers ( );
            }
        else
            {
            au.PlayOneShot ( SoundManager.defeated );
            }
        createLeaderBoardText ( );
      

       
     }

    // Update is called once per frame
    void Update()
    {
        
    }


    void insertToLeaderBoard ( )
        {
        for (int i = 0 ; i < listcapacity ; i++)
            {
            if (players [ i ].Score < GameManager.score)
                {
                playerindex = i;
                Player currentplayer = new Player(GameManager.first_name , GameManager.last_name , GameManager.score);
                players.Insert ( i,currentplayer );
                log.text = "<color=green>Congratulations! Your Name Is Added To The Leader Board....";
                StarparticleSystem.SetActive ( true );
                break;
                }
            }


        }

    void createLeaderBoardText ( )
        {
        GameObject g;

        for (int i = 0 ; i < listcapacity ; i++)
            {
            g = Instantiate ( textTemplate, LeaderBoardContent.transform);
            if (playerindex == i)
                {
                g.transform.GetChild ( 0 ).GetComponent<TMP_Text> ( ).text = $"<color=green>{ i + 1}. { players [ i ].FirstName} { players [ i ].LastName}";
                g.transform.GetChild ( 1 ).GetComponent<TMP_Text> ( ).text = $"<color=green>: { players [ i ].Score}";
                }
            else
                {
                g.transform.GetChild ( 0 ).GetComponent<TMP_Text> ( ).text = $"<color=white>{ i + 1}. { players [ i ].FirstName} { players [ i ].LastName}";
                g.transform.GetChild ( 1 ).GetComponent<TMP_Text> ( ).text = $"<color=white>: { players [ i ].Score}";
                }
            }
        }

    void saveplayers ( )
        {
        for (int i = playerindex ; i < listcapacity ; i++)
            {
            PlayerPrefs.SetString ( "fname" + i.ToString ( ) , players[i].FirstName );
            PlayerPrefs.SetString ( "lname" + i.ToString ( ),players[i].LastName );
            PlayerPrefs.SetInt("score" + i.ToString(), players[i].Score );
            }
        }

    public void GoToscene (string seanName )
        {
        StartCoroutine ( Utils.waitSeanLoader ( seanName,1f ) );
        }
     

    }
