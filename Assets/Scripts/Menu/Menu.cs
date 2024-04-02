using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class Menu : MonoBehaviour
{
    public AudioSource ads;
    public AudioClip click;
    public void newGame()
    {
        if (ads && click)
        {
            ads.PlayOneShot(click);
        }
        SceneManager.LoadScene("StoryScene");
    }

    public void doExitGame()
    {
        if (ads && click)
        {
            ads.PlayOneShot(click);
        }
        Application.Quit();
    }
}
