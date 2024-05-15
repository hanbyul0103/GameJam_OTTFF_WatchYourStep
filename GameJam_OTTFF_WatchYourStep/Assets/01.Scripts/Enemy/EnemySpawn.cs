using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private void OnEnable()
    {
        for(int i = 0; i < 2; i++)
        PoolManager.Instance.Pop("Enemy", transform);

        //GameManager.Instance.onEnemySpawn += Spawn;
        //UIManager.Instance.onEnemySpawn += Spawn;
    }

    private void OnDestroy()
    {
       // GameManager.Instance.onEnemySpawn -= Spawn;
        //UIManager.Instance.onEnemySpawn -= Spawn;
    }

    private void Spawn()
    {
        PoolManager.Instance.Pop("Enemy", transform.parent);
    }
}
