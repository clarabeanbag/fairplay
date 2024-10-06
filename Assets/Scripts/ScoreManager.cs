using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public TMP_Text scoreText;

    int score = 0;
    int totalScore = 50;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void CalculateScore(int deltaScore)
    {
        score += deltaScore; 
        scoreText.text = score.ToString();      
    } 

    public void SetTotalScore(int lvlscore)
    {
        totalScore = lvlscore;
    }
}
