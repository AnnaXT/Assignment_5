using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadHelp() {
        SceneManager.LoadScene("HelpScene");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Start Menu");
    }

}