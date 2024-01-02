using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State
    {
        Live, Death
    }
    private State currentState;

    #region MoveToNextPos
    [Header("MoveToNextPos")]
    [SerializeField] private List<Transform> points;
    [SerializeField] private int nextID = 0;
    [SerializeField] private float moveDistance = 10;
    [SerializeField] private float minSpeed = 5;
    [SerializeField] private float maxSpeed = 25;

    private float currentSpeed;
    private int _idChangeValue = 1;
    #endregion

    //private void Reset()
    //{
    //    Init();
    //}

    private void Init()
    {
        // root object 생성
        GameObject root = new GameObject(name + "_Root");
        root.transform.position = transform.position;
        transform.SetParent(root.transform);

        GameObject waypoints = new GameObject("Waypoints");
        waypoints.transform.SetParent(root.transform);

        GameObject p1 = new GameObject("Point1");
        p1.transform.SetParent(waypoints.transform);
        GameObject p2 = new GameObject("Point2");
        p2.transform.SetParent(waypoints.transform);

        p1.transform.position = RandomVector();
        p2.transform.position = RandomVector();

        while (Vector3.Distance(p1.transform.position, p2.transform.position) < moveDistance)
            RandomVector();

        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    private Vector3 RandomVector()
    {
        return new Vector3(Random.Range(-moveDistance, moveDistance), 0, Random.Range(-moveDistance, moveDistance));
    }

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        currentState = State.Live;
        currentSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    private void MoveToNextPoint() // 정해진 부분을 왔다갔다 이동
    {
        Transform goalPint = points[nextID];

        if (goalPint.transform.position.x > transform.position.x)
            transform.rotation = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z);
        else
            transform.rotation = Quaternion.Euler(transform.rotation.x, -90, transform.rotation.z);

        transform.position = Vector3.MoveTowards(transform.position, goalPint.position, currentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, goalPint.position) < 1f)
        {
            if (nextID == points.Count - 1)
                _idChangeValue = -1;

            if (nextID == 0)
                _idChangeValue = 1;

            nextID += _idChangeValue;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision != null)
        {
            currentState = State.Death;
        }
    }
}
