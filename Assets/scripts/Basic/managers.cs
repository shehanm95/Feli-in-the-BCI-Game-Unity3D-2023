using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

namespace mymanager
    {
    public class Player
        {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Score { get; set; }
        public Player ( string first_name,string last_name,int score )
            {
            FirstName = first_name;
            LastName = last_name;
            Score = score;
            }
        }

    static class Utils
        {
        public static bool mouthOpened;

        public static string FirstLetterUpper (string Word)
            {
            string UpperWord = Word.First ( ).ToString ( ).ToUpper ( ) + Word.Substring ( 1 );
            return UpperWord;
            }

        public static IEnumerator waitSeanLoader ( string SceneName,float waitTime )
            {
            yield return new WaitForSeconds ( waitTime );
            SceneManager.LoadScene ( SceneName );
            }
        public static IEnumerator waitSeanLoader ( string SceneName,float waitTime , AudioSource au )
            {
            au.PlayOneShot ( SoundManager.click1 );
            yield return new WaitForSeconds ( waitTime );
            SceneManager.LoadScene ( SceneName );
            }


        public static void textUpdater ( TMP_Text textObj,string text_value )
            {
            textObj.text = text_value;
            }


        public static IEnumerator RevealText (string fullText , TMP_Text textComponent , GameObject ObjectToActivate)
            {
            SoundManager.playsound ( SoundManager.typeSound );
            foreach (char c in fullText)
                {
                textComponent.text += c;
                float delaytime =Random.Range ( 0.1f,0.3f );
                yield return new WaitForSeconds ( delaytime );
                }
            SoundManager.stopSound ( );
            yield return new WaitForSeconds ( 1f );
            ObjectToActivate.gameObject.SetActive ( true );

            }
        public static IEnumerator RevealText ( string fullText,TMP_Text textComponent,GameObject ObjectToActivate , AudioSource audioSource )
            {
            audioSource.PlayOneShot ( SoundManager.typeSound );
            foreach (char c in fullText)
                {
                textComponent.text += c;
                float delaytime =Random.Range ( 0.01f,0.1f );
                yield return new WaitForSeconds ( delaytime );
                }
            audioSource.Stop ( );
            yield return new WaitForSeconds ( 1f );
            audioSource.PlayOneShot ( SoundManager.clickPop );
            ObjectToActivate.gameObject.SetActive ( true );

            }
        public static IEnumerator RevealText ( string fullText,TMP_Text textComponent,AudioSource audioSource )
            {
            mouthOpened = true;
            textComponent.text = "";
            audioSource.PlayOneShot ( SoundManager.typeSound );
            foreach (char c in fullText)
                {
                textComponent.text += c;
                float delaytime =Random.Range ( 0.01f,0.1f );
                yield return new WaitForSeconds ( delaytime );
                }
            audioSource.Stop ( );
            mouthOpened = false;
            }
        }



   

    }