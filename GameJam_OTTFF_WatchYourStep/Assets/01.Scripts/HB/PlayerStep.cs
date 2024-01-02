using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    public Action StepAction { get; set; }

    private Animator animator;

    private int screenWidth = 500;
    private int screenHeight = 800;

    private void OnEnable()
    {

    }

    private void Awake()
    {
        Screen.SetResolution(screenWidth, screenHeight, FullScreenMode.Windowed);
        animator = GetComponent<Animator>();
    }

    public void StopAnimation()
    {
        animator.speed = 0;
    }

    public void StepMethod()
    {
        StepAction?.Invoke();
    }

    private void OnDestroy()
    {
        StepAction -= StopAnimation;
    }
}
