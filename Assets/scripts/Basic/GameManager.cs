using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     public static string first_name,last_name , final_Text ="";
     public static int score , round , level , listcapacity = 6 , maxTries;
     public static bool gameover;
    void Start()
    {
        final_Text = "Your chances are finished.\n\n" +
        "* If you like, you can join our coding club:" +
        "\n\n" +
        "   - Learn Game Development.\n" +
        "   - Learn Web Development.\n" +
        "   - Learn Hacking and Cybersecurity.\n\n" +
        "Please go to the Registration desk and register now.\n\n" +
        "Hand over this PC to the next player.";
        maxTries = PlayerPrefs.GetInt ( "maxtries",3 );
        listcapacity = PlayerPrefs.GetInt ( "listcapacity",6 );
        }
    }
