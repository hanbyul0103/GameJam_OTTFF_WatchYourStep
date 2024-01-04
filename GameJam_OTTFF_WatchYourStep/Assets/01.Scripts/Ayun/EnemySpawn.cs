using System;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.onEnemySpawn += Spawn;
    }

    private void OnDestroy()
    {
        GameManager.Instance.onEnemySpawn -= Spawn;
    }

    private void Spawn()
    {
        PoolManager.Instance.Pop("Enemy", transform);
    }
}
