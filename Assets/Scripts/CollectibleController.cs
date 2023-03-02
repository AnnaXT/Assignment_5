using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectibleController : MonoBehaviour
{
    GameManager _gameManager;
    public static event Action OnCollected;
    public Player _playerController;
    public static int total;
    public AudioClip coinSound;

    void Awake() => total++;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(0f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position, 0.5f);
            _playerController.AttackAnimation();
            if (gameObject.CompareTag("Key"))
                _gameManager.SetKeyStatus(true);
            if (gameObject.CompareTag("StarLife"))
                _gameManager.UpdateLives(1);
            
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}