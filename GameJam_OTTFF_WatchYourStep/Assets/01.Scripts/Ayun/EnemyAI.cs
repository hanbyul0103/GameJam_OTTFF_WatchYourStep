using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public enum State
    {
        Live, Death
    }

    public Action<Vector3> onMovingPosition;

    [SerializeField] private float roamingDirChangeTime = 5f;
    private float randRoamingTime;

    private State currentState;
    private Vector3 roamingPosition;
    private float timeRoaming;

    private void Start()
    {
        roamingPosition = GetRoamingPosition();

        randRoamingTime = Random.Range(1f, roamingDirChangeTime);
    }

    private void Update()
    {
        if (currentState == State.Death) return;

        Roaming();
    }

    private void Roaming()
    {
        timeRoaming += Time.deltaTime;

        onMovingPosition?.Invoke(roamingPosition);

        if (timeRoaming > roamingDirChangeTime)
            roamingPosition = GetRoamingPosition();
    }

    Vector3 GetRoamingPosition()
    {
        timeRoaming = 0;
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision != null)
        {
            currentState = State.Death;
        }
    }
}
