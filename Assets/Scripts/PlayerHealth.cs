using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] 
    private int lifeVal = 1;
    //[SerializeField] 
    //private int score = 0;

    //public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI livesUI;
    public string levelName = "End Screen";

    
    private void Start()
    {
        //scoreUI.text = "SCORE: " + score;
        livesUI.text = lifeVal + " Coins";
    }

    private void Update(){
        //scoreUI.text = "SCORE: " + score;
        livesUI.text = lifeVal + " Coins";
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
    }

    public int getLife(){
        return lifeVal;
    }
    //public int getScore(){
    //    return score;
    //}

}
