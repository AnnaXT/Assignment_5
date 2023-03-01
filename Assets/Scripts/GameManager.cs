using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public Player _playerController;
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        var gms = GameObject.FindObjectsOfType<GameManager>();
        if (gms.Length > 1)
        {
            Destroy(gms[0].gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

    }

    public void SetPlayerControllerActive(bool activeMode)
    {
        _playerController.enabled = activeMode;
    }

    public bool PlayerMoveStatus()
    {
        return _navMeshAgent.velocity.magnitude > 0;
    }

    public void DirectPlayerTowards(Transform targetPosition)
    {
        Vector3 direction = targetPosition.position - player.transform.position;
        player.transform.rotation = Quaternion.LookRotation(direction);
    }


}
