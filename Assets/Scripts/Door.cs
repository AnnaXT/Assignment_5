using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    //public bool locked = true;
    public string levelToLoad;
    //int keyNum = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PublicVars.hasKey) 
            {
                PublicVars.hasKey = false;
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
}