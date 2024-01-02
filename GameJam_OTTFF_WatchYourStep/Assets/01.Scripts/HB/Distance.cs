using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI gameoverScoreTxt;
    [SerializeField] TextMeshProUGUI bestScoreTxt;

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
        scoreTxt.text = score.ToString();
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
        gameoverScoreTxt.text = score.ToString();
        CheckBestScore();
        bestScoreTxt.text = bestScore.ToString();
    }
}
