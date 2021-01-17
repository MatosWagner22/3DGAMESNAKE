using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Text highscore_text;

    void Start()
    {
        if (PlayerPrefs.GetInt("HIGHSCORE") != 0)
        {
            highscore_text.text = "High Score: " + PlayerPrefs.GetInt("HIGHSCORE");
        }

    }

    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}

