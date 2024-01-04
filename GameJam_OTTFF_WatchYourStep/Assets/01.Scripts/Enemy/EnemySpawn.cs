using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.onEnemySpawn += Spawn;
        UIManager.Instance.onEnemySpawn += Spawn;
    }

    private void OnDestroy()
    {
        GameManager.Instance.onEnemySpawn -= Spawn;
        UIManager.Instance.onEnemySpawn -= Spawn;
    }

    private void Spawn()
    {
        PoolManager.Instance.Pop("Enemy", transform);
    }
}
