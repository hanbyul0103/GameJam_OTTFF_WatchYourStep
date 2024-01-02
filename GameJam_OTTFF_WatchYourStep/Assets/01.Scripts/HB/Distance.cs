using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currenScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI scoreText;

    private PlayerStep playerStep;

    private int bestScore = 0;
    private int score = 0;
    private int distance = 1;
    private int combo;
    private int multiply = 1;

    private void OnEnable()
    {
        playerStep.StepAction += AddDistance;
    }

    private void Awake()
    {
        playerStep = FindObjectOfType<PlayerStep>();
    }

    private void Start()
    {
        score = 0;
    }

    private void CountCombo()
    {

    }

    public void AddDistance()
    {
        score += distance * multiply;
        Debug.Log($"score : {score}");
        currenScoreText.text = $"Step  :  {score.ToString("D3")}";
    }

    private void OnDestroy()
    {
        playerStep.StepAction -= AddDistance;
    }

    public void CheckBestScore()
    {
        if(score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestScore = PlayerPrefs.GetInt("BestScore");
        }
    }

    public void SetGameOver()
    {
        scoreText.text = score.ToString("D3");
        CheckBestScore();
        bestScoreText.text = bestScore.ToString();
    }
}
