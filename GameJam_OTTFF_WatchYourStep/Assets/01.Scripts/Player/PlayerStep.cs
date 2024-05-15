using System;
using System.Collections;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    public Action StepAction { get; set; }

    private Animator animator;

    public Transform[] effectTrm;

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

    public void LeftEffect()
    {
        StartCoroutine(StepEffect(1));
    }

    public void RightEffect()
    {
        StartCoroutine(StepEffect(0));
    }

    IEnumerator StepEffect(int indexnum)
    {
        GameObject effect = PoolManager.Instance.Pop("Effect", effectTrm[indexnum].position, Quaternion.Euler(-90, 0, 0));
        yield return new WaitForSeconds(.5f);
<<<<<<< Updated upstream
        PoolManager.Instance.Push("Effect",effect);
=======
        PoolManager.Instance.Push("Effect", effect);

>>>>>>> Stashed changes
    }

    private void OnDestroy()
    {
        StepAction -= StopAnimation;
        StepAction -= PlayStepSFX;
        StepAction -= SliderValuePlus;
    }
}
