using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private PlayerStep playerStep;
    public Transform playerOriginTransform;


    public float movementSpeed = 20.0f;

    private void Start()
    {
        playerStep.StepAction += Stop;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerStep = FindObjectOfType<PlayerStep>();
        playerOriginTransform = GameObject.Find("PlayerOriginPosition").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        if (GameManager.Instance.isGameStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("isGameStart", true);
                animator.speed = 1.5f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                animator.speed = 0.3f;
                movementSpeed = 10.0f;
            }

            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
    }

    public void Stop()
    {
        movementSpeed = 0;
    }

    public void SpeedUP()
    {
        movementSpeed = 20.0f;
    }

    private void OnDestroy()
    {
        playerStep.StepAction -= Stop;
    }
}
