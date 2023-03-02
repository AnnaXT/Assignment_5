using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectibleController : MonoBehaviour
{
    public static event Action OnCollected;
    public Player _playerController;
    public static int total;
    public AudioClip coinSound;

    void Awake() => total++;

    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position, 0.5f);
            _playerController.AttackAnimation();
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}