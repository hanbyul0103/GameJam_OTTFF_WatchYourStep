using System;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    public Action StepAction { get; set; }

    private Animator animator;

    private int screenWidth = 500;
    private int screenHeight = 800;

    private void OnEnable()
    {
        StepAction += StopAnimation;
        StepAction += PlayStepSFX;
        StepAction += SliderValuePlus;
    }

    private void Awake()
    {
        Screen.SetResolution(screenWidth, screenHeight, FullScreenMode.Windowed);
        animator = GetComponent<Animator>();
    }

    public void StepMethod()
    {
        StepAction?.Invoke();
    }

    public void StopAnimation()
    {
        animator.speed = 0;
    }

    private void PlayStepSFX()
    {
        AudioManager.Instance.PlaySFX("WalkingSound");
    }

    private void SliderValuePlus()
    {
        UIManager.Instance.SliderValueChangeing();
    }

    private void OnDestroy()
    {
        StepAction -= StopAnimation;
        StepAction -= PlayStepSFX;
        StepAction -= SliderValuePlus;
    }
}
