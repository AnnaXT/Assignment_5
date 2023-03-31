using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] 
    private int lifeVal = 3;
    //[SerializeField] 
    //private int score = 0;

    public AudioClip damageSound;
    AudioSource _audioSource;
    public TextMeshProUGUI livesUI;
    public string levelName = "End Screen";

    
    private void Start()
    {
        //scoreUI.text = "SCORE: " + score;
        livesUI.text = "Lives: " + lifeVal;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update(){
        //scoreUI.text = "SCORE: " + score;
        livesUI.text = "Lives: " + lifeVal;
        if (lifeVal <=0 ){
            SceneManager.LoadScene(levelName);
        }
    }

    //public void AddScore(int points){
    //    score += points;
    //    scoreUI.text = "SCORE: " + score;
    //}

    public void ChangeLifeVal(int newVal){
        lifeVal += newVal;
        livesUI.text = lifeVal + " Coins";
        if (newVal == -1){
            _audioSource.PlayOneShot(damageSound);
        }
    }

    public int getLife(){
        return lifeVal;
    }
    //public int getScore(){
    //    return score;
    //}

}
