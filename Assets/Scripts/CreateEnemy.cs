using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create(){
        Vector3 spwanPos1 = new Vector3(19f, 0.75f, 10f);
        Vector3 spwanPos2 = new Vector3(21f, 0.75f, 10f);
        Instantiate(enemy1, spwanPos1, Quaternion.identity);
        Instantiate(enemy2, spwanPos2, Quaternion.identity);
    }

}
