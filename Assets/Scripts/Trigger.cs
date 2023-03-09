using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public string tagName = "Player";
    public UnityEvent OnTriggerEnterEvent, OnTriggerExitEvent;
    GameManager _gameManager; 

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other){
        
        if(other.gameObject.CompareTag(tagName)){
            //other.GetComponent<PlayerHealth>().ChangeLifeVal(1);
            //_gameManager.UpdateLives(1);
            OnTriggerEnterEvent?.Invoke();
            //Destroy(gameObject);
            
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag(tagName)){
            OnTriggerExitEvent?.Invoke();
        }
    }
}
