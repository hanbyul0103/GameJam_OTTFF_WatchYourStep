using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!GameManager.Instance.isGameStart) return;

        if (Input.GetMouseButtonDown(0))
        {
            animator.speed = 1;
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.speed = 0.3f;
        }
    }
}
