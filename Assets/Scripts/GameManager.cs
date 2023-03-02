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
    public CameraController _cameraController;
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    public TextMeshProUGUI lifeSpan;
    public TextMeshProUGUI keyStatusText;
    public TextMeshProUGUI keyStatusMessageText;

    public bool keyStatus = false;
    public int lives;
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

    public void UpdateLives(int lifePoint)
    {
        if (lives > 0)
        {
            lives += lifePoint;
            lifeSpan.text = "Lives: " + lives.ToString();
        }
    }

    public void SetKeyStatus(bool newStatus)
    {
        if (newStatus) 
        {
            keyStatus = true;
            keyStatusText.text = "Key: Obtained";
        }
    }

    public void DisplayKeyNotObtainedError()
    {
        ShowTextForSeconds(keyStatusMessageText, 2f);
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
        StartCoroutine(WaitForSceneLoad(nextLevel));
    }

    private IEnumerator WaitForSceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(0);
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
