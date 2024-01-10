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

    [SerializeField] private float roamingDirChangeTime = 5f;
    private float randRoamingTime;

    private RaycastHit hit;
    private float maxDistance = 3f;

    private State currentState;
    private Vector3 roamingPosition;
    private float timeRoaming;

    private void Start()
    {
        //GameManager.Instance.onEnemySpawn += Push;
        UIManager.Instance.onEnemySpawn += Push;

        roamingPosition = GetRoamingPosition();

        randRoamingTime = Random.Range(1f, roamingDirChangeTime);
    }

    private void OnDestroy()
    {
        //GameManager.Instance.onEnemySpawn -= Push;
        UIManager.Instance.onEnemySpawn -= Push;
    }

    private void Push()
    {
        PoolManager.Instance.Push("Enemy", this.gameObject);
    }

    private void FixedUpdate()
    {
        if (currentState == State.Death) return;

        Roaming();
    }
    private void LateUpdate()
    {
        EnemyParentChange();
    }

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

    private void EnemyParentChange() // ¹Ø¿¡ ´ê¾ÆÀÖ´Â ¸ÊÀ¸·Î ºÎ¸ð º¯°æ
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxDistance))
        {
            transform.parent = hit.transform.parent;
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
