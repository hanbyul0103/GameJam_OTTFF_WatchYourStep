using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private PlayerStep playerStep;
    private TextMeshProUGUI currenScoreText;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI bestScoreText;
    
    private int score = 0;
    private int currentScore = 0;
    private int bestScore = 0;
    private int combo;
    private int distance = 1;
    private int multiply = 1;

    private void OnEnable()
    {
        playerStep.StepAction += AddDistance;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }

        playerStep = FindObjectOfType<PlayerStep>();

        currenScoreText = GameObject.Find("CurrentScoretext").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("Score/ScoreText").GetComponent<TextMeshProUGUI>();
        bestScoreText = GameObject.Find("BestScore/BestScoreText").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ResetScore();
    }

    public void ResetScore()
    {
        score = 0;
        currentScore = 0;
    }

    private void CountCombo()
    {

    }

    public void AddDistance()
    {
        score += distance * multiply;
        currentScore = score;
        currenScoreText.text = $"Step  :  {currentScore.ToString("D3")}";
    }

    public void CheckBestScore()
    {
        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            bestScore = PlayerPrefs.GetInt("BestScore");
        }
    }

    public void SetGameOver()
    {
        scoreText.text = currentScore.ToString("D3");
        CheckBestScore();
        bestScoreText.text = bestScore.ToString("D3");
    }

    private void OnDestroy()
    {
        playerStep.StepAction -= AddDistance;
    }
}
