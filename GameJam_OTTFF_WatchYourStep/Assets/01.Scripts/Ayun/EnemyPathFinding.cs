using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float maxMoveSpeed;
    private float randSpeed;

    private EnemyAI enemyAI;
    private Rigidbody rigid;
    Vector3 moveDir;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        enemyAI = GetComponent<EnemyAI>();

        enemyAI.onMovingPosition += MoveTo;
    }

    private void OnDestroy()
    {
        enemyAI.onMovingPosition -= MoveTo;
    }

    private void Start()
    {
        randSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    private void FixedUpdate()
    {
        rigid.velocity = moveDir * randSpeed;
    }

    void MoveTo(Vector3 targetPosition)
    {
        moveDir = targetPosition;
    }
}
