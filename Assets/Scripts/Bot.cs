using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent _newNavMeshAgent;
    GameObject player;
    private bool chase = true;
    public float interval = 2f;
    private float waitTime = 2f;

    void Start()
    {
        _newNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ChasePlayer());
        waitTime = interval;
    }

    IEnumerator ChasePlayer()
    {
        while (chase)
        {
        yield return new WaitForSeconds(0.5f);
        _newNavMeshAgent.destination = player.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            other.GetComponent<PlayerHealth>().ChangeLifeVal(-1);
            StopCoroutine("ChasePlayer");
            chase = false;
            
        }

    }

    private void Update(){
        if (chase == false){
            waitTime -= Time.deltaTime;
        }
        if (waitTime <= 0){
            waitTime = interval;
            chase = true;
            StartCoroutine("ChasePlayer");
        }

    }
}
