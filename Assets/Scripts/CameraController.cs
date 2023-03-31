using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public GameManager _gameManager; 
    public Vector3 offset;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    //private void LateUpdate()
    //{
    //    //if (!frontView)
    //      //transform.position = player.transform.position + offset;
    //}

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    if (!frontView) FrontViewAnimation();
        //    else TopViewAnimation();
        //    frontView = !frontView;
        //}
    }

    public void FrontViewAnimation()
    {
        StartCoroutine(WaitForPlayerToStop());
        _gameManager.SetPlayerControllerActive(false);
        animator.SetBool("FrontView", true);
        StartCoroutine(WaitForAnimationToFinish());
        _gameManager.DirectPlayerTowards(transform);
    }

    public void TopViewAnimation()
    {
        animator.SetBool("TopView", true);
        StartCoroutine(WaitForAnimationToFinish());
        _gameManager.SetPlayerControllerActive(true);
    }

    private IEnumerator WaitForPlayerToStop()
    {
        while (_gameManager.PlayerMoveStatus())
        {
            yield return null;
        }
    }

    private IEnumerator WaitForAnimationToFinish()
    {
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }
    }

    private IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
