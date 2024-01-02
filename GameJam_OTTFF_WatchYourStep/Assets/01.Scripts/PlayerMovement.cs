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
        if (Input.GetMouseButtonDown(0))
        {
            animator.speed = 3;
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.speed = 0.6f;
        }
    }
}
