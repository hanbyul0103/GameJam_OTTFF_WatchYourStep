using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    private PlayerStep playerStep;

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

    private void CountCombo()
    {

    }

    public void AddDistance()
    {
        score += distance * multiply;
        Debug.Log($"score : {score}");
    }

    private void OnDestroy()
    {
        playerStep.StepAction -= AddDistance;
    }
}
