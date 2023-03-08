using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 targetPosition = target.position + target.forward * offset.z - target.right * offset.x;
        nav.SetDestination(targetPosition);
        transform.LookAt(target);
    }
}