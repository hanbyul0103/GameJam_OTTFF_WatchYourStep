using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public enum State
    {
        Live, Death
    }

    public Action<Vector3> onMovingPosition;

    [SerializeField] private LayerMask gameobjectLayer;
    [SerializeField] private float roamingDirChangeTime = 5f;
    private float randRoamingTime;

    private RaycastHit hit;
    private float maxDistance = 3f;

    private State currentState;
    private Vector3 roamingPosition;
    private float timeRoaming;

    private void Start()
    {
        GameManager.Instance.onEnemySpawn += Push;
        UIManager.Instance.onEnemySpawn += Push;

        roamingPosition = GetRoamingPosition();

        randRoamingTime = Random.Range(1f, roamingDirChangeTime);
    }

    private void OnDestroy()
    {
        GameManager.Instance.onEnemySpawn -= Push;
        UIManager.Instance.onEnemySpawn -= Push;
    }

    private void Push()
    {
        PoolManager.Instance.Push("Enemy", this.gameObject);
    }

    private void Update()
    {
        if (currentState == State.Death) return;

        Roaming();
    }

    //private void RangeCheack()
    //{
    //    Collider[] colliders = Physics.OverlapSphere(transform.position + new Vector3(0, 1, 0), sphereRadius);

    //    if (colliders != null)
    //    {
    //        foreach (Collider collider in colliders)
    //        {
    //            if (collider.gameObject.tag == "Enemy")
    //            {
    //                roamingPosition = collider.gameObject.transform.position - transform.position;
    //            }
    //        }
    //    }
    //}

    private void Roaming()
    {
        timeRoaming += Time.deltaTime;

        onMovingPosition?.Invoke(roamingPosition);
        this.transform.rotation = Quaternion.LookRotation(roamingPosition);

        if (timeRoaming > randRoamingTime)
            roamingPosition = GetRoamingPosition();

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, out hit, maxDistance))
        {
            if (hit.transform.gameObject.tag == "Enemy")
                return;

            roamingPosition = GetRoamingPosition();
        }
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
