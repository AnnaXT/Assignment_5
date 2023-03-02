using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotWithWait : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent _newNavMeshAgent;
    GameObject player;

    private bool chase = false;
    public float interval = 2f;
    private float waitTime = 2f;
    private bool started = false;

    void Start()
    {
        _newNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        waitTime = interval;
    }

    public void StartChase(){
        chase = true;
        started = true;
        StartCoroutine(ChasePlayer());
    }

    IEnumerator ChasePlayer()
    {
        while (chase)
        {
        _newNavMeshAgent.destination = player.transform.position;
        yield return new WaitForSeconds(1);
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
        if (chase == false && started){
            waitTime -= Time.deltaTime;
        }
        if (waitTime <= 0){
            waitTime = interval;
            chase = true;
            StartCoroutine("ChasePlayer");
        }

    }
}
