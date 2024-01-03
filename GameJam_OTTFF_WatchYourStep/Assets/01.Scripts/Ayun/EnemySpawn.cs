using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private void OnEnable()
    {
        for (int i = 0; i < 5; i++)
        {
            PopEnemy();
        }
    }


    private void PopEnemy()
    {
        PoolManager.Instance.Pop("Enemy", transform);
    }
}
