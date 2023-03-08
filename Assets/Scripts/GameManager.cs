using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player _playerController;
    public GameObject player;
    public GameObject key;
    public CameraController _cameraController;
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    public TextMeshProUGUI lifeSpan;
    public TextMeshProUGUI keyStatusText;
    public TextMeshProUGUI keyStatusMessageText;
    // Replacing player health script for Anna
    public string deathLevelName = "Death Scene";
    public AudioClip damageSound;



    public bool keyStatus = false;
    public static int lives = 1;
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
        lifeSpan.text = "Lives: " + lives.ToString();
    }

    public void UpdateLives(int lifePoint)
    {
        lives += lifePoint;
        lifeSpan.text = "Lives: " + lives.ToString();
        if (lifePoint < 0)
        {
            player.GetComponent<AudioSource>().PlayOneShot(damageSound);
        }
        if (lives <= 0)
        {
            // Anna, if you want to edit anything, do it here
    
            //SceneManager.LoadScene(deathLevelName);
            StartCoroutine(WaitForSceneLoad(deathLevelName, 1));
        }
    }

    public void SetKeyStatus(bool newStatus)
    {
        if (newStatus)
        {
            key.GetComponent<CollectibleController>().enabled = false;
            key.GetComponent<FollowTarget>().enabled = true;
            key.GetComponent<Collider>().enabled = false;
            keyStatus = true;
            keyStatusText.text = "Baby: Found!";
        }
    }

    public void DisplayKeyNotObtainedError()
    {
        StartCoroutine(ShowTextForSeconds(keyStatusMessageText, 2f));
    }

    public void StartGame()
    {
        _playerController.enabled = true;
        _navMeshAgent.enabled = true;
        _cameraController.TopViewAnimation();
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

    public void LoadScene(string nextLevel)
    {
        _cameraController.FrontViewAnimation();
        StartCoroutine(WaitForSceneLoad(nextLevel, 2));
    }

    private IEnumerator WaitForSceneLoad(string sceneName, int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    private IEnumerator ShowTextForSeconds(TextMeshProUGUI text, float seconds)
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        text.gameObject.SetActive(false);
    }
}