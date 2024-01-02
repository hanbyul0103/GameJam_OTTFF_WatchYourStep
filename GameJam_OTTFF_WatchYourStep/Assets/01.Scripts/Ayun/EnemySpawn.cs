using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            PopEnemy();
        }
    }

    private void PopEnemy()
    {
        PoolManager.Instance.Pop("Enemy", transform);
    }
}
