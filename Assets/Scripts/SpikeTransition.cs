using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTransition : MonoBehaviour
{
    public Animator myAnimator;
    GameManager _gameManager;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("Player")){
            myAnimator.Play("Open Trap");
            _gameManager.UpdateLives(-1);
            //other.GetComponent<PlayerHealth>().ChangeLifeVal(-1);
        }
        

    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            myAnimator.Play("Close Trap");
        }
        
    }


}
