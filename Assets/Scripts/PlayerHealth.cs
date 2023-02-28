using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] 
    private int lifeVal = 1;
    //[SerializeField] 
    //private int score = 0;

    //public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI livesUI;

    
    private void Start()
    {
        //scoreUI.text = "SCORE: " + score;
        livesUI.text = lifeVal + " Coins";
    }

    private void Update(){
        //scoreUI.text = "SCORE: " + score;
        livesUI.text = lifeVal + " Coins";
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
