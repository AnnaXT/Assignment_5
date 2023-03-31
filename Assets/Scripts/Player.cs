using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Player : MonoBehaviour
{
    NavMeshAgent _newNavMeshAgent;
    GameManager _gameManager;
    Camera mainCam;
    Animator animator;

    public string nextScene;

    void Start()
    {
        _newNavMeshAgent = GetComponent<NavMeshAgent>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200))
            {
                // print(hit.point);
                _newNavMeshAgent.destination = hit.point;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            if (_gameManager.keyStatus == true)
            {
                Destroy(other.gameObject);
                _gameManager.LoadScene(nextScene);
            }
            else
            {
                _gameManager.DisplayKeyNotObtainedError();
            }

        }
    }


    // private void OnTriggerEnter(Collider other)
    // {
    //    if (other.CompareTag("Key"))
    //    {
    //        int keyNum = Int32.Parse(other.name.Substring(3)); // all key must be named "Key" andm numner "Key0"
    //        Destroy(other.gameObject);
    //        PublicVars.hasKey[keyNum] = true;
    //    }

    public void AttackAnimation()
    {
        animator.SetBool("Attack", true);
    }

}

