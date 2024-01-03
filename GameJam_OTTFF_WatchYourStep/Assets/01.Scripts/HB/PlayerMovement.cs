using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private PlayerStep playerStep;

    private float movementSpeed = 20.0f;

    private void OnEnable()
    {
        playerStep.StepAction += Stop;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerStep = FindObjectOfType<PlayerStep>();
    }

    private void Update()
    {
        if (!GameManager.Instance.isGameStart) return;

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isGameStart", true);
            animator.speed = 1.5f;
            movementSpeed = 20.0f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.speed = 0.3f;
        }

        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }

    public void Stop()
    {
        movementSpeed = 0;
    }

    private void OnDestroy()
    {
        playerStep.StepAction -= Stop;
    }
}
