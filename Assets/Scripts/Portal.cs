using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public float positionX, positionY, positionZ;
    public string tagName = "Player";
    Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    private void OnTriggerEnter(Collider other){
        
        if(other.gameObject.CompareTag(tagName)){
            //other.transform.position = new Vector3(positionX, positionY, positionZ);
            other.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(new Vector3(positionX, positionY, positionZ));
        }
    }
}
